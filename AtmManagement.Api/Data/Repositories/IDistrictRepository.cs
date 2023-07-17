using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

namespace AtmManagement.Api.Data.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        Task<IEnumerable<DistrictDto>> GetAllDistrict();
        Task<DistrictDto> GetDistrictById(int id);
        Task UpdateDistrict(DistrictDto atmDto);
        Task AddDistrict(DistrictDto atmDto);
        Task DeleteDistrict(int id);
    }
}
