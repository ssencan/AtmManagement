using AtmManagement.Api.Dtos;

namespace AtmManagement.Api.Services
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllCity();
        Task<CityDto> GetCityById(int id);
        Task UpdateCity(CityDto cityDto);
        Task<CityDto> AddCity(CityDto cityDto);
        Task DeleteCity(int id);
    }
}
