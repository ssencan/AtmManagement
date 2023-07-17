using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtmManagement.Api.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DistrictDto>> GetAllDistrict()
        {
            var districts = await _unitOfWork.Districts.GetAllDistrict();
            return districts;
        }

        public async Task<DistrictDto> GetDistrictById(int id)
        {
            var district = await _unitOfWork.Districts.GetDistrictById(id);
            return district;
        }

        public async Task UpdateDistrict(DistrictDto districtDto)
        {
            var district = await _unitOfWork.Districts.GetDistrictById(districtDto.Id);
            if (district == null)
                throw new Exception("District not found");
            await _unitOfWork.Districts.UpdateDistrict(districtDto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<DistrictDto> AddDistrict(DistrictDto districtDto)
        {
            await _unitOfWork.Districts.AddDistrict(districtDto);
            await _unitOfWork.SaveChangesAsync();
            return districtDto;
        }

        public async Task DeleteDistrict(int id)
        {
            var district = await _unitOfWork.Districts.GetDistrictById(id);
            if (district == null)
                throw new Exception("District not found");
            await _unitOfWork.Districts.DeleteDistrict(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
