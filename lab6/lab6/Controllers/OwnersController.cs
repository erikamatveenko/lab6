using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using lab6.Data;
using lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace lab6.Controllers
{
    [Route("api/[controller]")]
    public class OwnersController : Controller
    {
        private readonly UchetDbContext _context;
        public OwnersController(UchetDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<Owner> Get()
        {
            return _context.Owners.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Owner owner = _context.Owners.FirstOrDefault(x => x.OwnerID == id);
            if (owner == null)
                return NotFound();
            return new ObjectResult(owner);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Owner owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }

            _context.Owners.Add(owner);
            _context.SaveChanges();
            return Ok(owner);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Owner owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }
            if (!_context.Owners.Any(x => x.OwnerID == owner.OwnerID))
            {
                return NotFound();
            }

            _context.Update(owner);
            _context.SaveChanges();
            return Ok(owner);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Owner owner = _context.Owners.FirstOrDefault(x => x.OwnerID == id);
            if (owner == null)
            {
                return NotFound();
            }
            _context.Owners.Remove(owner);

            var cars = _context.Cars.Include(c => c.Owner).Where(s => s.OwnerID == id);
            _context.Cars.RemoveRange(cars);

            _context.SaveChanges();
            return Ok(owner);
        }
    }
}
