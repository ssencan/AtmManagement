using AtmManagement.Api.Dtos;

namespace AtmManagement.Api.Services
{
    public interface IAtmService
    {
        Task<AtmDto> Add(AtmDto atmDto);
    }
}
