using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission06_LastName.Data;
using Mission06_LastName.Models;

// MoviesController.cs
// Handles all movie-related actions including:
// - Displaying movie list
// - Showing the Create form
// - Saving new movies to the database

namespace Mission06_LastName.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieCollectionContext _context;

        public MoviesController(MovieCollectionContext context)
        {
            _context = context;
        }

        // Optional list page (nice for checking your DB)
        public IActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.OrderBy(c => c.Name), "CategoryId", "Name");
            return View(new Movie());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            // Rebuild dropdown if validation fails
            ViewBag.Categories = new SelectList(_context.Categories.OrderBy(c => c.Name), "CategoryId", "Name");

            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}