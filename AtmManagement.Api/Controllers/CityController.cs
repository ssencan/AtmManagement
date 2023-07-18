using AtmManagement.Api.Dtos;
using AtmManagement.Api.Services;
using AtmManagement.Api.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AtmManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
            var cities = await _cityService.GetAllCity();
            return Ok(cities);
        }

        // GET: api/Cities/id
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            var cityDto = await _cityService.GetCityById(id);

            if (cityDto == null)
            {
                return NotFound();
            }

            return Ok(cityDto);
        }

        // PUT: api/Cities
        [HttpPut]
        public async Task<IActionResult> PutCity(CityDto cityDto)
        {
            var validator = new CityDtoValidator();
            var validationResult = await validator.ValidateAsync(cityDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            try
            {
                await _cityService.UpdateCity(cityDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Cities/CreateCity
        [HttpPost("CreateCity")]
        public async Task<ActionResult<CityDto>> PostCity(CityDto cityDto)
        {
            var validator = new CityDtoValidator();
            var validationResult = await validator.ValidateAsync(cityDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var result = await _cityService.AddCity(cityDto);

            return CreatedAtAction(nameof(GetCity), new { id = result.Id }, result);
        }

        // DELETE: api/Cities/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                await _cityService.DeleteCity(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
