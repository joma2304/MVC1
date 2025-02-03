using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC1.Models;

namespace MVC1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Message = "Hem"; //ViewBag för hem
        ViewData["Welcome-text"] = "Välkommen till startsidan för denna webbplats";
        return View();
    }

    public IActionResult MVC()
    {
        ViewBag.Message = "MVC"; //ViewBag för MVC
        ViewData["Welcome-text"] = "Test ....";
        return View();
    }

    public IActionResult About()
    {
        ViewBag.Message = "Om Sidan"; //ViewBag för Om 
        ViewData["Welcome-text"] = "Test ....";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
