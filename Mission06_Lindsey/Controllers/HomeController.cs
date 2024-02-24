using Microsoft.AspNetCore.Mvc;
using Mission06_Lindsey.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace Mission06_Lindsey.Controllers
{
    public class HomeController : Controller
    {
        private JoelHiltonMovieCollectionContext _context;
        public HomeController(JoelHiltonMovieCollectionContext temp) 
        { 
            _context = temp;
        }

       // private MovieCollectionContext _context;
       // public HomeController(MovieCollectionContext temp) 
       // { 
       //     _context = temp;
       // }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            ViewBag.categories = _context.Categories.ToList();

            return View("Form", new Movie());
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpPost]
       public IActionResult Form(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // add to database
                _context.SaveChanges();

                return View("Confirm", response);
            }
            else
            {
                ViewBag.categories = _context.Categories.ToList();
                return View(response);
            }

            
        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies.Include(x => x.Category).ToList();
              
            return View(movies);
        }

        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id);

            ViewBag.categories = _context.Categories.ToList();
            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo) 
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var recordToDelete = _context.Movies
              .Single(x => x.MovieID == id);

            ViewBag.categories = _context.Categories.ToList();

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
