using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesContext _moviesContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MoviesContext movies)
        {
            _logger = logger;
            _moviesContext = movies;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Movie()
        {
            ViewBag.Category = _moviesContext.categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movie(MovieForm mf)
        {
            if (ModelState.IsValid)
            {
                _moviesContext.Add(mf);
                _moviesContext.SaveChanges();
                return View("MvConfirm", mf);
            }
            ViewBag.Category = _moviesContext.categories.ToList();
            return View(mf);
        }
        public IActionResult MovieList()
        {
            var movies = _moviesContext.Responses
                .Include(x => x.categories)
                .ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Category = _moviesContext.categories.ToList();
            var movie = _moviesContext.Responses.Single(x => x.movieId == movieid);
            return View("Movie", movie);
        }
        [HttpPost]
        public IActionResult Edit(MovieForm mf)
        {
            _moviesContext.Update(mf);
            _moviesContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _moviesContext.Responses.Single(x => x.movieId == movieid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieForm mf)
        {
            _moviesContext.Remove(mf);
            _moviesContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
