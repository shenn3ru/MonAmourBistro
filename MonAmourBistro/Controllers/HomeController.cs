using Microsoft.AspNetCore.Mvc;

namespace MonAmourBistro.Controllers;

public class HomeController : Controller
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Acasă";
        ViewData["IsHome"] = true;
        return View();
    }

    [HttpGet("/despre-noi")]
    public IActionResult About()
    {
        ViewData["Title"] = "Despre noi";
        return View("Page");
    }

    [HttpGet("/galerie")]
    public IActionResult Gallery()
    {
        ViewData["Title"] = "Galerie";
        return View("Page");
    }

    [HttpGet("/contact")]
    public IActionResult Contact()
    {
        ViewData["Title"] = "Contact";
        return View("Page");
    }

    [HttpGet("/confidentialitate")]
    public IActionResult Privacy()
    {
        ViewData["Title"] = "Politica de confidențialitate";
        return View("Page");
    }

    [HttpGet("/eroare")]
    public IActionResult Error()
    {
        ViewData["Title"] = "Eroare";
        return View("Page");
    }
}