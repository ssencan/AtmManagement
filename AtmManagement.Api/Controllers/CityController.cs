using AtmManagement.Api.Data.Repositories;
using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;
using AtmManagement.Api.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AtmManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IRepository<City> _cityRepository;

        public CityController(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
            var cities = await _cityRepository.GetAllAsync();
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
            var city = await _cityRepository.GetByIdAsync(id);

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
            var validator = new CityDtoValidator();
            var validationResult = await validator.ValidateAsync(cityDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var city = await _cityRepository.GetByIdAsync(cityDto.Id);
            if (city == null)
            {
                return NotFound();
            }
            city.CityName = cityDto.Name;
            city.PlateNumber = cityDto.PlateNumber;

            await _cityRepository.UpdateAsync(city);

            return NoContent();
        }

        // POST: api/Cities
        [HttpPost("CreateCity")]
        public async Task<ActionResult<CityDto>> PostCity(CityDto cityDto)
        {
            var validator = new CityDtoValidator();
            var validationResult = await validator.ValidateAsync(cityDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }

            var city = new City();
            city.CityName = cityDto.Name;
            city.PlateNumber = cityDto.PlateNumber;

            await _cityRepository.AddAsync(city);

            return CreatedAtAction(nameof(GetCity), new { id = city.ID }, cityDto);
        }

        // DELETE: api/Cities/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            await _cityRepository.DeleteAsync(city.ID);

            return NoContent();
        }
    }
}
