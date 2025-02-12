using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6_assignment.Models;

namespace mission6_assignment.Controllers;

public class HomeController : Controller
{
    private MoviesAppContext _context;

    public HomeController(MoviesAppContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    [HttpGet]
    public IActionResult EnterMovies()
    {
        //you have to either change the asp link or put the actual view in the ()
        //if you leave it blank it will just look for the name of the class
        return View();
    }
    [HttpPost]
    public IActionResult EnterMovies(Application application)
    {
        _context.Applications.Add(application);
        _context.SaveChanges();
        //we want to see the response
        return View("Confirmation", application);
    }
}