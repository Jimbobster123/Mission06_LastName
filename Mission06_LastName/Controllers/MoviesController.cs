using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission06_LastName.Data;
using Mission06_LastName.Models;

namespace Mission06_LastName.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieCollectionContext _context;

        public MoviesController(MovieCollectionContext context)
        {
            _context = context;
        }

        // LIST: /Movies
        public IActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();

            return View(movies);
        }

        // EDIT GET: /Movies/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound();

            ViewBag.Categories = new SelectList(
                _context.Categories.OrderBy(c => c.CategoryName),
                "CategoryId",
                "CategoryName",
                movie.CategoryId
            );

            return View(movie);
        }

        // EDIT POST: /Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie updatedMovie)
        {
            if (id != updatedMovie.MovieId) return BadRequest();

            ViewBag.Categories = new SelectList(
                _context.Categories.OrderBy(c => c.CategoryName),
                "CategoryId",
                "CategoryName",
                updatedMovie.CategoryId
            );

            if (!ModelState.IsValid)
            {
                return View(updatedMovie);
            }

            _context.Movies.Update(updatedMovie);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // DELETE GET: /Movies/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Category)
                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null) return NotFound();

            return View(movie);
        }

        // DELETE POST: /Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);
            if (movie == null) return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}