using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtmManagement.Api.Entities;
using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;

namespace AtmManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly AtmDbContext _context;

        public DistrictController(AtmDbContext context)
        {
            _context = context;
        }

        // GET: api/District
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistrictDto>>> GetDistricts()
        {
            var districts = await _context.Districts
                 .Select(d => new DistrictDto
                 {
                     Id = d.ID,
                     Name = d.DistrictName,
                     CityId = d.CityID
                 }).ToListAsync();

            if (!districts.Any())
            {
                return NotFound();
            }

            return districts;
        }

        // GET: api/District/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DistrictDto>> GetDistrict(int id)
        {
            var district = await _context.Districts
                       .Select(d => new DistrictDto
                       {
                           Id = d.ID,
                           Name = d.DistrictName,
                           CityId = d.CityID
                       })
                       .FirstOrDefaultAsync(d => d.Id == id);

            if (district == null)
            {
                return NotFound();
            }

            return district;
        }


        // PUT: api/District/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutDistrict(DistrictDto districtDto)
        {
            var district = await _context.Districts.FindAsync(districtDto.Id);
            if (district == null)
            {
                return NotFound();
            }

            district.DistrictName = districtDto.Name;
            district.CityID = districtDto.CityId;

            _context.Entry(district).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(districtDto.Id))
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
        // POST: api/District
        [HttpPost("CreateDistrict")]
        public async Task<ActionResult<DistrictDto>> PostDistrict(DistrictDto districtDto)
        {
            var district = new District
            {
                DistrictName = districtDto.Name,
                CityID = districtDto.CityId
            };

            _context.Districts.Add(district);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDistrict), new { id = district.ID }, districtDto);
        }

        // DELETE: api/District/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            var district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DistrictExists(int id)
        {
            return (_context.Districts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
