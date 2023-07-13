using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtmManagement.Api.Entities;
using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;
using AtmManagement.Api.Validators;

namespace AtmManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly AtmDbContext _context;

        public CityController(AtmDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
            var cities = await _context.Cities.ToListAsync();
            var cityDtos = cities.Select(city => new CityDto
            {
                Id = city.ID,
                Name = city.CityName,
                PlateNumber = city.PlateNumber
            });
            return Ok(cityDtos);
        }

        // GET: api/Cities/id
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            var cityDto = new CityDto
            {
                Id = city.ID,
                Name = city.CityName,
                PlateNumber = city.PlateNumber
            };
            return Ok(cityDto);
        }

        // PUT: api/Cities/id
        [HttpPut]
        public async Task<IActionResult> PutCity(CityDto cityDto)
        {
            var city = await _context.Cities.FindAsync(cityDto.Id);
            if (!CityExists(city.ID))
            {
                return NotFound();
            }
            city.CityName = cityDto.Name;
            city.PlateNumber = cityDto.PlateNumber;
            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Cities
        [HttpPost("CreateCity")]
        public async Task<ActionResult<City>> PostCity(CityDto cityDto)
        {
            var validator = new CityDtoValidator();
            var validationResult = await validator.ValidateAsync(cityDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
            }

            var city = new City();
            city.CityName = cityDto.Name;
            city.PlateNumber = cityDto.PlateNumber;

            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCity), new { id = city.ID }, cityDto);
        }

        // DELETE: api/Cities/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.ID == id);
        }
    }
}
