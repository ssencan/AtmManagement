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
    public class AtmController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtmController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Atms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtmDto>>> GetAtms()
        {
            var atms = await _unitOfWork.Atms.GetAllAtm();

            return Ok(atms);
        }

        // GET: api/Atms/id
        [HttpGet("{id}")]
        public async Task<ActionResult<AtmDto>> GetAtm(int id)
        {
            var atmDto = await _unitOfWork.Atms.GetAtmById(id);

            if (atmDto == null)
            {
                return NotFound();
            }

            return Ok(atmDto);
        }

        // PUT: api/Atms
        [HttpPut]
        public async Task<IActionResult> PutAtm(AtmDto atmDto)
        {
            var validator = new AtmDtoValidator();
            var validationResult = await validator.ValidateAsync(atmDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            await _unitOfWork.Atms.UpdateAtm(atmDto);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Atms/CreateAtm
        [HttpPost("CreateAtm")]
        public async Task<ActionResult<AtmDto>> PostAtm(AtmDto atmDto)
        {
            var validator = new AtmDtoValidator();
            var validationResult = await validator.ValidateAsync(atmDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            await _unitOfWork.Atms.AddAtm(atmDto);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAtm), new { id = atmDto.Id }, atmDto);
        }

        // DELETE: api/Atms/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtm(int id)
        {
            await _unitOfWork.Atms.DeleteAtm(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
