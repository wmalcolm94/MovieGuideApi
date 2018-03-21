using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieGuideApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieGuideApi.Controllers 
{
    [Route("api/[controller]")]
    public class UserEventController : Controller 
    {
        private readonly MovieGuideContext _context;

        public UserEventController(MovieGuideContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<UserEvent> Get()
        {
            List<UserEvent> results = _context.UserEvent
                                                    .Include(x => x.evnt)
                                                    .Include(x => x.user)
                                                    .ToList();
            return results;
        }

        [HttpGet("{id}", Name = "GetUserEvent")]
        public IActionResult Get(int id)
        {
            var result = _context.UserEvent
                                        .Include(x => x.evnt)
                                        .Include(x => x.user)
                                        .FirstOrDefault(x => x.id == id);
            if (result == null)
                return NotFound();

            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody]UserEvent item)
        {
            if (item == null)
                return BadRequest();

            _context.UserEvent.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetUserEvent", new { id = item.id }, item);
        }

        [HttpPut]
        public IActionResult Update(long id, [FromBody] UserEvent item)
        {
            if (item == null || item.id != id)
                return BadRequest();

            var userEvent = _context.UserEvent
                                            .Include(x => x.user)
                                            .Include(x => x.evnt)
                                            .FirstOrDefault(x => x.id == id);
            if (userEvent == null)
                return NotFound();

            userEvent.eventId = item.eventId;
            userEvent.evnt = item.evnt;
            userEvent.user = item.user;
            userEvent.userId = item.userId;

            _context.UserEvent.Update(userEvent);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult Delete (long id)
        {
            var user = _context.UserEvent.FirstOrDefault(x => x.id == id);
            if (user == null)  
                return NotFound();

            _context.UserEvent.Remove(user);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}