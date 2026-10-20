using Microsoft.AspNetCore.Mvc;

namespace MonAmourBistro.Controllers;

[Route("admin")]
public class AdminController : Controller
{
    [HttpGet("")]
    [SimAuthorize(SimRole.Administrator)]
    public IActionResult Index()
    {
        ViewData["Title"] = "Panou de administrare";
        ViewData["Section"] = "dashboard";
        return View("Index");
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return Redirect("/autentificare");
    }

    [HttpGet("meniu")]
    [SimAuthorize(SimRole.Administrator)]
    public IActionResult Menu()
    {
        ViewData["Title"] = "Gestiunea meniului";
        ViewData["Section"] = "menu";
        return View("Index");
    }

    [HttpGet("pagini")]
    [SimAuthorize(SimRole.Administrator)]
    public IActionResult Pages()
    {
        ViewData["Title"] = "Gestiunea paginilor";
        ViewData["Section"] = "pages";
        return View("Index");
    }

    [HttpGet("rezervari")]
    [SimAuthorize(SimRole.Administrator)]
    public IActionResult Reservations()
    {
        ViewData["Title"] = "Lista rezervărilor";
        ViewData["Section"] = "reservations";
        return View("Index");
    }
}
