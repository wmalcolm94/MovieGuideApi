using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieGuideApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieGuideApi.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly MovieGuideContext _context;

        public EventController(MovieGuideContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            List<Event> results = _context.Event
                                        .Include(x => x.chat)
                                        .Include(x => x.userEvents)
                                        .ToList();
            return results;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetEvent")]
        public IActionResult Get(int id)
        {
            var result = _context.Event
                                    .Include(x => x.chat)
                                    .Include(x => x.userEvents)
                                    .FirstOrDefault(x => x.id == id);
            if (result == null)
                return NotFound();

            return new ObjectResult(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]Event item)
        {
            if (item == null)
                return BadRequest();

            _context.Event.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetEvent", new { id = item.id }, item);
        }

        [HttpPut]
        public IActionResult Update(long id, [FromBody] Event item)
        {
            if (item == null || item.id != id)
                return BadRequest();

            var even = _context.Event
                                    .Include(x => x.userEvents)
                                    .FirstOrDefault(x => x.id == id);
            if (even == null)
                return NotFound();

            even.name = item.name;
            even.date = item.date;
            even.userEvents = item.userEvents;

            _context.Event.Update(even);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var even = _context.Event.FirstOrDefault(x => x.id == id);
            if (even == null)
                return NotFound();

            _context.Event.Remove(even);
            _context.SaveChanges();
            
            return new NoContentResult();
        }
    }
}
