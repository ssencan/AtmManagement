using AtmManagement.Api.Data.Repositories;
using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;
using AtmManagement.Api.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AtmManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        private readonly IRepository<Atm> _atmRepository;

        public AtmController(IRepository<Atm> atmRepository)
        {
            _atmRepository = atmRepository;
        }

        // GET: api/Atms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtmDto>>> GetAtms()
        {
            var atms = await _atmRepository.GetAllAsync();
            var atmDtos = atms.Select(atm => new AtmDto
            {
                Id = atm.ID,
                AtmName = atm.AtmName,
                Latitude = atm.Latitude,
                Longitude = atm.Longitude,
                IsActive = atm.IsActive,
                CityID = atm.CityID,
                DistrictID = atm.DistrictID
            });
            return Ok(atmDtos);
        }

        // GET: api/Atms/id
        [HttpGet("{id}")]
        public async Task<ActionResult<AtmDto>> GetAtm(int id)
        {
            var atm = await _atmRepository.GetByIdAsync(id);

            if (atm == null)
            {
                return NotFound();
            }

            var atmDto = new AtmDto
            {
                Id = atm.ID,
                AtmName = atm.AtmName,
                Latitude = atm.Latitude,
                Longitude = atm.Longitude,
                IsActive = atm.IsActive,
                CityID = atm.CityID,
                DistrictID = atm.DistrictID
            };
            return Ok(atmDto);
        }

        // PUT: api/Atms/id
        [HttpPut]
        public async Task<IActionResult> PutAtm(AtmDto atmDto)
        {
            var validator = new AtmDtoValidator();
            var validationResult = await validator.ValidateAsync(atmDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var atm = await _atmRepository.GetByIdAsync(atmDto.Id);
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

            await _atmRepository.UpdateAsync(atm);

            return NoContent();
        }

        // POST: api/Atms
        [HttpPost("CreateAtm")]
        public async Task<ActionResult<AtmDto>> PostAtm(AtmDto atmDto)
        {
            var validator = new AtmDtoValidator();
            var validationResult = await validator.ValidateAsync(atmDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var atm = new Atm
            {
                AtmName = atmDto.AtmName,
                Latitude = atmDto.Latitude,
                Longitude = atmDto.Longitude,
                IsActive = atmDto.IsActive,
                CityID = atmDto.CityID,
                DistrictID = atmDto.DistrictID
            };

            await _atmRepository.AddAsync(atm);

            return CreatedAtAction(nameof(GetAtm), new { id = atm.ID }, atmDto);
        }

        // DELETE: api/Atms/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtm(int id)
        {
            var atm = await _atmRepository.GetByIdAsync(id);
            if (atm == null)
            {
                return NotFound();
            }

            await _atmRepository.DeleteAsync(atm.ID);

            return NoContent();
        }
    }
}
