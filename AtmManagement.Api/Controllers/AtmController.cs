using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;
using AtmManagement.Api.Services;
using AtmManagement.Api.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AtmManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        private readonly IAtmService _atmService;


        public AtmController(IAtmService atmService)
        {
            _atmService = atmService;
        }

        // GET: api/Atms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtmDto>>> GetAtms()
        {
            var atms = await _atmService.GetAllAtm();

            return Ok(atms);
        }

        // GET: api/Atms/id
        [HttpGet("{id}")]
        public async Task<ActionResult<AtmDto>> GetAtm(int id)
        {
            var atmDto = await _atmService.GetAtmById(id);

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
            try
            {
                await _atmService.UpdateAtm(atmDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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

            var result = await _atmService.AddAtm(atmDto);

            return CreatedAtAction(nameof(GetAtm), new { id = result.Id }, result);
        }

        // DELETE: api/Atms/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtm(int id)
        {
            await _atmService.DeleteAtm(id);

            return NoContent();
        }
    }
}
