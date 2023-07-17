using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

namespace AtmManagement.Api.Data.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        Task<IEnumerable<DistrictDto>> GetAllAtm();
        Task<DistrictDto> GetAtmById(int id);
        Task UpdateAtm(DistrictDto atmDto);
        Task AddAtm(DistrictDto atmDto);
        Task DeleteAtm(int id);
    }
}
