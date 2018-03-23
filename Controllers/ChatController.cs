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
            List<Chat> results = _context.Chat.ToList();
            foreach (var item in results)
            {
                _context.Entry(item).Reference(x => x.movie).Load();
                _context.Entry(item).Collection(x => x.messages).Load();
            }
            return results;
        }

        [HttpGet("{id}", Name = "GetChat")]
        public IActionResult Get(int id)
        {
            var result = _context.Chat
                                    .Include(x => x.messages)
                                    .FirstOrDefault(x => x.id == id);
            if (result == null)
                return NotFound();
            
            _context.Entry(result).Reference(x => x.movie).Load();
            _context.Entry(result).Collection(x => x.messages).Load();

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