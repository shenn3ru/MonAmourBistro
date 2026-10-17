using Microsoft.AspNetCore.Mvc;

namespace MonAmourBistro.Controllers;

public class MenuController : Controller
{
    [HttpGet("/meniu")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Meniu";
        return View("Page");
    }
}