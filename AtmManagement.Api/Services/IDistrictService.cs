using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

namespace AtmManagement.Api.Services
{
    public interface IDistrictService
    {
        Task<IEnumerable<DistrictDto>> GetAllDistrict();
        Task<DistrictDto> GetDistrictById(int id);
        Task<District> UpdateDistrict(DistrictDto districtDto);
        Task<DistrictDto> AddDistrict(DistrictDto districtDto);
        Task<District> DeleteDistrict(int id);
    }
}
