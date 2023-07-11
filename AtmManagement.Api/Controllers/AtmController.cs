using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtmManagement.Api.Entities;
using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;

namespace AtmManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        private readonly AtmDbContext _context;

        public AtmController(AtmDbContext context)
        {
            _context = context;
        }

        // GET: api/Atms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtmDto>>> GetAtms()
        {
            return await _context.Atms.Select(a => new AtmDto
            {
                Id = a.ID,
                AtmName = a.AtmName,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                IsActive = a.IsActive,
                CityID = a.CityID,
                DistrictID = a.DistrictID
            }).ToListAsync();
        }

        // GET: api/Atms/id
        [HttpGet("{id}")]
        public async Task<ActionResult<AtmDto>> GetAtm(int id)
        {
            var atm = await _context.Atms.FindAsync(id);

            if (atm == null)
            {
                return NotFound();
            }

            return new AtmDto
            {
                Id = atm.ID,
                AtmName = atm.AtmName,
                Latitude = atm.Latitude,
                Longitude = atm.Longitude,
                IsActive = atm.IsActive,
                CityID = atm.CityID,
                DistrictID = atm.DistrictID
            };
        }

        // PUT: api/Atms/id
        [HttpPut]
        public async Task<IActionResult> PutAtm(AtmDto atmDto)
        {
            var atm = await _context.Atms.FindAsync(atmDto.Id);
            if (atm == null)
            {
                return NotFound();
            }

            atm.AtmName = atmDto.AtmName;
            atm.Latitude = atmDto.Latitude;
            atm.Longitude = atmDto.Longitude;
            atm.IsActive = atmDto.IsActive;
            atm.CityID = atmDto.CityID;
            atm.DistrictID = atmDto.DistrictID;

            _context.Entry(atm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtmExists(atmDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Atms
        [HttpPost("CreateAtm")]
        public async Task<ActionResult<AtmDto>> CreateAtm(AtmDto atmDto)
        {
            var atm = new Atm
            {
                AtmName = atmDto.AtmName,
                Latitude = atmDto.Latitude,
                Longitude = atmDto.Longitude,
                IsActive = atmDto.IsActive,
                CityID = atmDto.CityID,
                DistrictID = atmDto.DistrictID
            };

            _context.Atms.Add(atm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAtm), new { id = atm.ID }, atmDto);
        }

        // DELETE: api/Atms/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtm(int id)
        {
            var atm = await _context.Atms.FindAsync(id);
            if (atm == null)
            {
                return NotFound();
            }

            _context.Atms.Remove(atm);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool AtmExists(int id)
        {
            return (_context.Atms?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
