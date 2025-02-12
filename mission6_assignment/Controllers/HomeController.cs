using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6_assignment.Models;

namespace mission6_assignment.Controllers;

//connects to the database for our instances
public class HomeController : Controller
{
    private MoviesAppContext _context;

    public HomeController(MoviesAppContext temp)
    {
        _context = temp;
    }

    //connect to the index view 
    public IActionResult Index()
    {
        return View();
    }

    //connect to the gettoknowjoel view
    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    //get the enter movies form
    [HttpGet]
    public IActionResult EnterMovies()
    {
        //you have to either change the asp link or put the actual view in the ()
        //if you leave it blank it will just look for the name of the class
        return View();
    }
    
    //send to the actual server, and make sure you save it to the database so you dont have to update it
    [HttpPost]
    public IActionResult EnterMovies(Application application)
    {
        _context.Applications.Add(application);
        _context.SaveChanges();
        //we want to see the response
        return View("Confirmation", application);
    }
}