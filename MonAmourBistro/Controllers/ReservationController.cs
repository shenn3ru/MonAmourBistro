using Microsoft.AspNetCore.Mvc;

namespace MonAmourBistro.Controllers;

public class ReservationController : Controller
{
    [HttpGet("/rezervare")]
    [SimAuthorize(SimRole.Client)]
    public IActionResult Index()
    {
        ViewData["Title"] = "Rezervă o masă";
        return View();
    }
}
