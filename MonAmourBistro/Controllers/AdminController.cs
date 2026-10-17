using Microsoft.AspNetCore.Mvc;

namespace MonAmourBistro.Controllers;

[Route("admin")]
public class AdminController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Panou de administrare";
        return View("Page");
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        ViewData["Title"] = "Autentificare administrator";
        return View("Page");
    }

    [HttpGet("meniu")]
    public IActionResult Menu()
    {
        ViewData["Title"] = "Gestiunea meniului";
        return View("Page");
    }

    [HttpGet("pagini")]
    public IActionResult Pages()
    {
        ViewData["Title"] = "Gestiunea paginilor";
        return View("Page");
    }

    [HttpGet("rezervari")]
    public IActionResult Reservations()
    {
        ViewData["Title"] = "Lista rezervărilor";
        return View("Page");
    }
}