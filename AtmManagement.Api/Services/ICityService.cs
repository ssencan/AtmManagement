using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

namespace AtmManagement.Api.Services
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllCity();
        Task<CityDto> GetCityById(int id);
        Task<City> UpdateCity(CityDto cityDto);
        Task<CityDto> AddCity(CityDto cityDto);
        Task<City> DeleteCity(int id);
    }
}
