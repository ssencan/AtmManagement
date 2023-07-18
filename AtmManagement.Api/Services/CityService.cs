using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;

namespace AtmManagement.Api.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CityDto>> GetAllCity()
        {
            var cities = await _unitOfWork.Cities.GetAllCity();
            return cities;
        }

        public async Task<CityDto> GetCityById(int id)
        {
            var city = await _unitOfWork.Cities.GetCityById(id);
            return city;
        }

        public async Task<City> UpdateCity(CityDto cityDto)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(cityDto.Id);

            if (city == null)
                return null;

            city.CityName = cityDto.Name;
            city.PlateNumber = cityDto.PlateNumber;
            await _unitOfWork.SaveChangesAsync();
            return city;
        }

        public async Task<CityDto> AddCity(CityDto cityDto)
        {
            var city = new City
            {
                CityName = cityDto.Name,
                PlateNumber = cityDto.PlateNumber
            };
            await _unitOfWork.Cities.AddAsync(city);
            await _unitOfWork.SaveChangesAsync();
            return cityDto;
        }

        public async Task<City> DeleteCity(int id)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            if (city == null)
                return null;
            await _unitOfWork.SaveChangesAsync();
            return city;
        }
    }
}
