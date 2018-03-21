using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieGuideApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieGuideApi.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly MovieGuideContext _context;

        public ChatController (MovieGuideContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Chat> Get()
        {
            List<Chat> results = _context.Chat
                                            .Include(x => x.evnt)
                                            .Include(x => x.messages)
                                            .ToList();
            return results;
        }

        [HttpGet("{id}", Name = "GetChat")]
        public IActionResult Get(int id)
        {
            var result = _context.Chat
                                    .Include(x => x.evnt)
                                    .Include(x => x.messages)
                                    .FirstOrDefault(x => x.id == id);
            if (result == null)
                return NotFound();

            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Chat item)
        {
            if (item == null)
                return BadRequest();

            _context.Chat.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetChat", new { id = item.id }, item);
        }

        [HttpPut]
        public IActionResult Update(long id, [FromBody] Chat item)
        {
            if (item == null || item.id != id)
                return BadRequest();
            
            var chat = _context.Chat.FirstOrDefault(x => x.id == id);
            if (chat == null)
                return NotFound();

            chat.eventId = item.eventId;
            chat.evnt = item.evnt;
            chat.messages = item.messages;

            _context.Chat.Update(chat);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var chat = _context.Chat.FirstOrDefault(x => x.id == id);
            if (chat == null)
                return NotFound();

            _context.Chat.Remove(chat);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}