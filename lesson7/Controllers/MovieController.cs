using System.Collections.Generic;
using System.Linq;
using lesson7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lesson7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Inception",
                Director = "Christopher Nolan",
                Year = 2010,
                Genre = "Sci-Fi"
            },

            new Movie
            {
                Id = 2,
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Year = 2008,
                Genre = "Action"
            },

            new Movie
            {
                Id = 3,
                Title = "Interstellar",
                Director = "Christopher Nolan",
                Year = 2014,
                Genre = "Sci-Fi"
            }
        };

        [Authorize]
        [HttpGet]
        public IActionResult GetMovies(string search, string genre, int? year)
        {
            List<Movie> result = movies;

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(m => m.Title.ToLower().Contains(search.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(genre))
            {
                result = result.Where(m => m.Genre == genre).ToList();
            }

            if (year.HasValue)
            {
                result = result.Where(m => m.Year == year.Value).ToList();
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            Movie movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}