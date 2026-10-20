using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MonAmourBistro.Controllers;

// Ordinea contează: Administrator are tot ce are Client, iar Client tot ce are Vizitator.
public enum SimRole
{
    Vizitator = 0,
    Client = 1,
    Administrator = 2
}

// Ajutor pentru simulare: rolul curent este ținut într-un cookie (fără parole, fără bază de date).
public static class Sim
{
    public const string CookieName = "mab_role";

    public static SimRole Current(HttpContext ctx)
    {
        return ctx.Request.Cookies[CookieName] switch
        {
            "client" => SimRole.Client,
            "admin" => SimRole.Administrator,
            _ => SimRole.Vizitator
        };
    }

    public static string Label(SimRole role) => role switch
    {
        SimRole.Client => "Client",
        SimRole.Administrator => "Administrator",
        _ => "Vizitator"
    };
}

// Se pune pe o acțiune: [SimAuthorize(SimRole.Client)]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SimAuthorizeAttribute : ActionFilterAttribute
{
    private readonly SimRole _minimum;

    public SimAuthorizeAttribute(SimRole minimum)
    {
        _minimum = minimum;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (Sim.Current(context.HttpContext) >= _minimum)
        {
            return;
        }

        var path = context.HttpContext.Request.Path.Value ?? "/";
        context.Result = new RedirectResult(
            $"/acces-interzis?necesar={(int)_minimum}&pagina={Uri.EscapeDataString(path)}");
    }
}

public class RolesController : Controller
{
    [HttpGet("/roluri")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Roluri și acces";
        return View();
    }

    [HttpGet("/roluri/seteaza/{rol}")]
    public IActionResult Set(string rol, string? returnUrl)
    {
        switch (rol.ToLowerInvariant())
        {
            case "client":
            case "admin":
                Response.Cookies.Append(Sim.CookieName, rol.ToLowerInvariant(), new CookieOptions
                {
                    HttpOnly = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.Lax
                });
                break;
            default:
                Response.Cookies.Delete(Sim.CookieName);
                break;
        }

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return Redirect("/roluri");
    }

    [HttpGet("/acces-interzis")]
    public IActionResult Denied(int necesar = 1, string? pagina = null)
    {
        ViewData["Title"] = "Acces interzis";
        ViewData["Needed"] = necesar >= 2 ? SimRole.Administrator : SimRole.Client;
        ViewData["Target"] = string.IsNullOrEmpty(pagina) ? "/" : pagina;
        return View();
    }
}