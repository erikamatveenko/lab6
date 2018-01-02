using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using lab6.Data;
using lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace lab6.Controllers
{
    [Route("api/[controller]")]
    public class BrandsController : Controller
    {
        private readonly UchetDbContext _context;
        public BrandsController(UchetDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<Brand> Get()
        {
            return _context.Brands.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(x => x.BrandID == id);
            if (brand == null)
                return NotFound();
            return new ObjectResult(brand);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Brand brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }

            _context.Brands.Add(brand);
            _context.SaveChanges();
            return Ok(brand);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Brand brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            if (!_context.Brands.Any(x => x.BrandID == brand.BrandID))
            {
                return NotFound();
            }

            _context.Update(brand);
            _context.SaveChanges();
            return Ok(brand);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(x => x.BrandID == id);
            if (brand == null)
            {
                return NotFound();
            }
            _context.Brands.Remove(brand);

            var cars = _context.Cars.Include(c => c.Brand).Where(s => s.BrandID == id);
            _context.Cars.RemoveRange(cars);

            _context.SaveChanges();
            return Ok(brand);
        }
    }
}
