using Microsoft.AspNetCore.Mvc;

namespace MonAmourBistro.Controllers;

public class ReservationController : Controller
{
    [HttpGet("/rezervare")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Rezervă o masă";
        return View("Page");
    }
}