using AtmManagement.Api.Data;
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
    public class DistrictController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/District
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistrictDto>>> GetDistricts()
        {
            var districts = (await _unitOfWork.Districts.GetAllAsync())
                .Select(d => new DistrictDto
                {
                    Id = d.ID,
                    Name = d.DistrictName,
                    CityId = d.CityID
                }).ToList();

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
            var districtEntity = await _unitOfWork.Districts.GetByIdAsync(id);

            if (districtEntity == null)
            {
                return NotFound();
            }

            var district = new DistrictDto
            {
                Id = districtEntity.ID,
                Name = districtEntity.DistrictName,
                CityId = districtEntity.CityID
            };

            return district;
        }

        // PUT: api/District/5
        [HttpPut]
        public async Task<IActionResult> PutDistrict(DistrictDto districtDto)
        {
            var validator = new DistrictDtoValidator();
            var validationResult = await validator.ValidateAsync(districtDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var districtEntity = await _unitOfWork.Districts.GetByIdAsync(districtDto.Id);
            if (districtEntity == null)
            {
                return NotFound();
            }

            districtEntity.DistrictName = districtDto.Name;
            districtEntity.CityID = districtDto.CityId;

            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/District
        [HttpPost("CreateDistrict")]
        public async Task<ActionResult<DistrictDto>> PostDistrict(DistrictDto districtDto)
        {
            var validator = new DistrictDtoValidator();
            var validationResult = await validator.ValidateAsync(districtDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var districtEntity = new District
            {
                DistrictName = districtDto.Name,
                CityID = districtDto.CityId
            };

            await _unitOfWork.Districts.AddAsync(districtEntity);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDistrict), new { id = districtEntity.ID }, districtDto);
        }

        // DELETE: api/District/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            var districtEntity = await _unitOfWork.Districts.GetByIdAsync(id);
            if (districtEntity == null)
            {
                return NotFound();
            }

            await _unitOfWork.Districts.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
