using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC1.Models;
using Newtonsoft.Json;

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

    public IActionResult Persons()
    {
        ViewBag.Message = "Personer"; //ViewBag för personer
        ViewData["Welcome-text"] = "Här är en lista med personer:";
        var jsonStr = System.IO.File.ReadAllText("persons.json");
        var JsonObj = JsonConvert.DeserializeObject<IEnumerable<Persons>>(jsonStr);
        return View(JsonObj);
    }

    public IActionResult About()
    {
        ViewBag.Message = "Om Sidan"; //ViewBag för Om 
        ViewData["Welcome-text"] = "Test ....";
        return View();
    }
}
