using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieGuideApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieGuideApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly MovieGuideContext _context;

        public UserController(MovieGuideContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            List<User> results = _context.User.ToList();
            return results;
        }

        [HttpGet("{id}", Name = "GetUsers")]
        public IActionResult Get(int id)
        {
            var result = _context.User.FirstOrDefault(x => x.id == id);
            if (result == null)
                return NotFound();

            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody]User item)
        {
            if (item == null)
                return BadRequest();

            _context.User.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = item.id }, item);
        }

        [HttpPut]
        public IActionResult Update(long id, [FromBody] User item)
        {
            if (item == null || item.id != id)
                return BadRequest();

            var user = _context.User.FirstOrDefault(x => x.id == id);
            if (user == null)
                return NotFound();
            
            user.name = item.name;
            user.email = item.email;
            user.password = item.password;

            _context.User.Update(user);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var user = _context.User.FirstOrDefault(x => x.id == id);
            if (user == null)
                return NotFound();

            _context.User.Remove(user);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}