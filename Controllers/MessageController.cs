using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieGuideApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieGuideApi.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly MovieGuideContext _context;

        public MessageController(MovieGuideContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            List<Message> results = _context.Message
                                                .Include(x => x.chat)
                                                .Include(x => x.user)
                                                .ToList();
            return results;
        }

        [HttpGet("{id}", Name = "GetMessage")]
        public IActionResult Get(int id)
        {
            var result = _context.Message
                                        .Include(x => x.chat)
                                        .Include(x => x.user)
                                        .FirstOrDefault(x => x.id == id);
            if (result == null)
                return NotFound();

            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Message item)
        {
            if (item == null)
                return BadRequest();

            _context.Message.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMessage", new { id = item.id }, item);
        }

        [HttpPut]
        public IActionResult Update(long id, [FromBody]Message item)
        {
            if (item == null || item.id != id)
                return BadRequest();

            var message = _context.Message
                                        .Include(x => x.chat)
                                        .Include(x => x.user)
                                        .FirstOrDefault(x => x.id == id);
            if (message == null)
                return NotFound();

            message.message = item.message;
            message.chatId = item.chatId;
            message.chat = item.chat;
            message.sent = item.sent;
            message.userId = item.userId;
            message.user = item.user;
            _context.Message.Update(message);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var message = _context.Message.FirstOrDefault(x => x.id == id);
            if (message == null)
                return NotFound();

            _context.Message.Remove(message);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}