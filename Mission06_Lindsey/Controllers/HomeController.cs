using Microsoft.AspNetCore.Mvc;
using Mission06_Lindsey.Models;
using System.Diagnostics;

namespace Mission06_Lindsey.Controllers
{
    public class HomeController : Controller
    {
        private MovieCollectionContext _context;
        public HomeController(MovieCollectionContext temp) 
        { 
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(AddMovie response)
        {
            _context.addMovies.Add(response); // add to database
            _context.SaveChanges();

            return View("Confirm", response);
        }
    }
}
