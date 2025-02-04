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

    [HttpGet]
    public IActionResult AddPerson()
    {
        ViewBag.Message = "Lägg till personer"; //ViewBag för personer
        ViewData["Welcome-text"] = "Fyll i förmuläret nedan för att lägga till en person:";
        return View();
    }

    [HttpPost]
    public IActionResult AddPerson(Persons newPerson)
    {

        if (!ModelState.IsValid) //Ifall inte valideras korrekt
        {
            return View(newPerson); // Skicka tillbaka formuläret med felmeddelanden
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "persons.json");

        // Läs in befintliga personer
        var jsonStr = System.IO.File.ReadAllText(filePath);
        var personList = JsonConvert.DeserializeObject<List<Persons>>(jsonStr) ?? new List<Persons>();

        // Lägg till den nya personen
        personList.Add(newPerson);

        // Spara tillbaka till jsonfilen
        var updatedJson = JsonConvert.SerializeObject(personList, Formatting.Indented);
        System.IO.File.WriteAllText(filePath, updatedJson);

        return RedirectToAction("Persons"); //Skickas till sidan med personer
    }
}
