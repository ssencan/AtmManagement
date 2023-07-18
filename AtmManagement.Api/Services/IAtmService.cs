using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

namespace AtmManagement.Api.Services
{
    public interface IAtmService
    {
        Task<IEnumerable<AtmDto>> GetAllAtm();
        Task<AtmDto> GetAtmById(int id);
        Task<Atm> UpdateAtm(AtmDto atmDto);
        Task<AtmDto> AddAtm(AtmDto atmDto);
        Task<Atm> DeleteAtm(int id);
    }
}
