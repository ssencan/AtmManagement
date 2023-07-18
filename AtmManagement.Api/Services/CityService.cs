using AtmManagement.Api.Data;
using AtmManagement.Api.Dtos;

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

        public async Task UpdateCity(CityDto cityDto)
        {
            var city = await _unitOfWork.Cities.GetCityById(cityDto.Id);
            if (city == null)
                throw new Exception("City not found");
            await _unitOfWork.Cities.UpdateCity(cityDto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CityDto> AddCity(CityDto cityDto)
        {
            await _unitOfWork.Cities.AddCity(cityDto);
            await _unitOfWork.SaveChangesAsync();
            return cityDto;
        }

        public async Task DeleteCity(int id)
        {
            var city = await _unitOfWork.Cities.GetCityById(id);
            if (city == null)
                throw new Exception("City not found");
            await _unitOfWork.Cities.DeleteCity(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
