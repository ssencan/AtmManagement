using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

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

        public async Task<District> UpdateDistrict(DistrictDto districtDto)
        {
            var district = await _unitOfWork.Districts.GetByIdAsync(districtDto.Id);

            if (district == null)
                return null;

            district.DistrictName = districtDto.Name;
            district.CityID = districtDto.CityId;

            await _unitOfWork.SaveChangesAsync();
            return district;
        }

        public async Task<DistrictDto> AddDistrict(DistrictDto districtDto)
        {
            var district = new District
            {
                DistrictName = districtDto.Name,
                CityID = districtDto.CityId
            };
            await _unitOfWork.Districts.AddAsync(district);
            await _unitOfWork.SaveChangesAsync();
            return districtDto;
        }

        public async Task<District> DeleteDistrict(int id)
        {
            var district = await _unitOfWork.Districts.GetByIdAsync(id);
            if (district == null)
                return null;
            await _unitOfWork.SaveChangesAsync();
            return district;
        }
    }
}
