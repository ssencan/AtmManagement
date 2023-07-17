using AtmManagement.Api.Dtos;

namespace AtmManagement.Api.Services
{
    public interface IDistrictService
    {
        Task<IEnumerable<DistrictDto>> GetAllDistrict();
        Task<DistrictDto> GetDistrictById(int id);
        Task UpdateDistrict(DistrictDto districtDto);
        Task<DistrictDto> AddDistrict(DistrictDto districtDto);
        Task DeleteDistrict(int id);
    }
}
