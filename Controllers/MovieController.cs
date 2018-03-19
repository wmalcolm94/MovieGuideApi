using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieGuideApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieGuideApi.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly MovieGuideContext _context;

        public MovieController(MovieGuideContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            List<Movie> results = _context.Movie.ToList();
            return results;
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetAction(int id)
        {
            var result = _context.Movie.FirstOrDefault(x => x.id == id);
            if (result == null)
                return NotFound();

            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Movie item)
        {
            if (item == null)
                return BadRequest();

            _context.Movie.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMovie", new { id = item.id }, item);
        }

        [HttpPut]
        public IActionResult Update(long id, [FromBody] Movie item)
        {
            if (item == null || item.id != id)
                return BadRequest();

            var movie = _context.Movie.FirstOrDefault(x => x.id == id);

            if (movie == null)
                return NotFound();

            movie.name = item.name;
            
            _context.Movie.Update(movie);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var movie = _context.Movie.FirstOrDefault(x => x.id == id);
            if (movie == null)
                return NotFound();

            _context.Movie.Remove(movie);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}