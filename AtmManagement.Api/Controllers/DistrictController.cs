﻿using AtmManagement.Api.Dtos;
using AtmManagement.Api.Services;
using AtmManagement.Api.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AtmManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        // GET: api/District
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistrictDto>>> GetDistricts()
        {
            var districts = await _districtService.GetAllDistrict();
            return Ok(districts);
        }

        // GET: api/District/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DistrictDto>> GetDistrict(int id)
        {
            var districtDto = await _districtService.GetDistrictById(id);

            if (districtDto == null)
            {
                return NotFound("Kayıt bulunamadı. Id =" + id);
            }

            return Ok(districtDto);
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

            try
            {
                await _districtService.UpdateDistrict(districtDto);
                var data = await _districtService.UpdateDistrict(districtDto);
                if (data == null)
                {
                    return NotFound("Kayıt bulunamadı. Id =" + districtDto.Id);
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

            var result = await _districtService.AddDistrict(districtDto);

            return CreatedAtAction(nameof(GetDistrict), new { id = result.Id }, result);
        }

        // DELETE: api/District/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            var data = await _districtService.DeleteDistrict(id);
            await _districtService.DeleteDistrict(id);
            if (data == null)
            {
                return NotFound("Kayıt bulunamadı. Id =" + id);
            }
            return NoContent();
        }
    }
}
