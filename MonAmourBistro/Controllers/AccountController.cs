using Microsoft.AspNetCore.Mvc;

namespace MonAmourBistro.Controllers;

public class AccountController : Controller
{
    [HttpGet("/inregistrare")]
    public IActionResult Register()
    {
        // În simulare, înregistrarea și autentificarea sunt aceeași pagină.
        return Redirect("/autentificare");
    }

    [HttpGet("/autentificare")]
    public IActionResult Login()
    {
        ViewData["Title"] = "Autentificare";
        return View();
    }

    [HttpGet("/cont")]
    [SimAuthorize(SimRole.Client)]
    public IActionResult MyAccount()
    {
        ViewData["Title"] = "Contul meu";
        return View();
    }
}
