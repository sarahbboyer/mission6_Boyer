using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6_assignment.Models;
using Microsoft.EntityFrameworkCore;



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
        ViewBag.Categories = _context.Categories.ToList();
        //you have to either change the asp link or put the actual view in the ()
        //if you leave it blank it will just look for the name of the class
        return View("EnterMovies", new Movie());
    }
    
    //send to the actual server, and make sure you save it to the database so you dont have to update it
    [HttpPost]
    public IActionResult EnterMovies(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        //we want to see the response
        return View("Confirmation", movie);
    }
    public IActionResult MoviesList()
    {
        //this is creating a list
        var applications = _context.Movies
            //join tables
            .Include(x =>x.Category)
            .ToList();
        return View(applications);
    }
        
    //the name here does matter, you want it to match your route and pattern
    //you can pass in multiple things here
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies.Find(id);
        ViewBag.Categories = _context.Categories.ToList();
        return View("EnterMovies", recordToEdit);
    }
    
    //send to the actual server
    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        // this is calling the view not the action
        //return View("WaitList");
        //you need to use the action instead
        return RedirectToAction("MoviesList");
    }
    
    //delete get, use id route to get the id   
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x=> x.MovieId == id);
        return View(recordToDelete);
    }
    
    //save deleted movie 
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        //set up the action
        _context.Movies.Remove(movie);
        //confirm in actual database
        _context.SaveChanges();
        return RedirectToAction("MoviesList");
    }
}

