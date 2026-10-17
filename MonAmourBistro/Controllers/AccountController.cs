using Microsoft.AspNetCore.Mvc;

namespace MonAmourBistro.Controllers;

public class AccountController : Controller
{
    [HttpGet("/inregistrare")]
    public IActionResult Register()
    {
        ViewData["Title"] = "Înregistrare";
        return View("Page");
    }

    [HttpGet("/autentificare")]
    public IActionResult Login()
    {
        ViewData["Title"] = "Autentificare";
        return View("Page");
    }

    [HttpGet("/cont")]
    public IActionResult MyAccount()
    {
        ViewData["Title"] = "Contul meu";
        return View("Page");
    }
}