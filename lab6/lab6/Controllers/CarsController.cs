using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using lab6.Data;
using lab6.Models;
using Microsoft.EntityFrameworkCore;
using lab6.ViewModels;

namespace lab6.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly UchetDbContext _context;
        public CarsController(UchetDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<CarViewModel> Get()
        {
            return _context.Cars.Include(b => b.Brand).Include(o => o.Owner).Select(c =>
            new CarViewModel
            {
                BrandID = c.BrandID,
                BrandName = c.Brand.BrandName,
                CarColor = c.CarColor,
                CarID = c.CarID,
                CarNumberOfPassport = c.CarNumberOfPassport,
                CarRegistrationNumber = c.CarRegistrationNumber,
                CarReleaseDate = c.CarReleaseDate,
                OwnerID = c.OwnerID,
                OwnerName = c.Owner.OwnerName
            });
        }

        // GET api/values
        [HttpGet("brands")]
        [Produces("application/json")]
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }
        // GET api/values
        [HttpGet("owners")]
        [Produces("application/json")]
        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Car car = _context.Cars.FirstOrDefault(x => x.CarID == id);
            if (car == null)
                return NotFound();
            return new ObjectResult(car);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            _context.Cars.Add(car);
            _context.SaveChanges();
            return Ok(car);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            if (!_context.Cars.Any(x => x.CarID == car.CarID))
            {
                return NotFound();
            }

            _context.Update(car);
            _context.SaveChanges();
            return Ok(car);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Car car = _context.Cars.FirstOrDefault(x => x.CarID == id);
            if (car == null)
            {
                return NotFound();
            }
            _context.Cars.Remove(car);

          
            _context.SaveChanges();
            return Ok(car);
        }
    }
}
