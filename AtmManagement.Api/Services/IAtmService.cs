using AtmManagement.Api.Dtos;

namespace AtmManagement.Api.Services
{
    public interface IAtmService
    {
        Task<IEnumerable<AtmDto>> GetAllAtm();
        Task<AtmDto> GetAtmById(int id);
        Task UpdateAtm(AtmDto atmDto);
        Task<AtmDto> AddAtm(AtmDto atmDto);
        Task DeleteAtm(int id);
    }
}
