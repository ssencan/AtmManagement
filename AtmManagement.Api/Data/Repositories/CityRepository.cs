// CityRepository
using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AtmManagement.Api.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AtmDbContext context) : base(context)
        {
        }

        private AtmDbContext AtmDbContext
        {
            get { return _context as AtmDbContext; }
        }

        public async Task<IEnumerable<CityDto>> GetAllCity()
        {
            var query = from city in AtmDbContext.Cities
                        select new CityDto
                        {
                            Id = city.ID,
                            Name = city.CityName,
                            PlateNumber = city.PlateNumber
                        };
            return await query.ToListAsync();
        }

        public async Task<CityDto> GetCityById(int id)
        {
            var city = await GetByIdAsync(id);

            if (city == null)
                return null;

            var cityDto = new CityDto
            {
                Id = city.ID,
                Name = city.CityName,
                PlateNumber = city.PlateNumber
            };

            return cityDto;
        }

        public async Task UpdateCity(CityDto cityDto)
        {
            var city = await GetByIdAsync(cityDto.Id);

            if (city == null)
                return;

            city.CityName = cityDto.Name;
            city.PlateNumber = cityDto.PlateNumber;

            Update(city);
        }

        public async Task AddCity(CityDto cityDto)
        {
            var city = new City
            {
                CityName = cityDto.Name,
                PlateNumber = cityDto.PlateNumber
            };

            Add(city);
            await CommitAsync();
        }

        public async Task DeleteCity(int id)
        {
            var city = await GetByIdAsync(id);

            if (city == null)
                return;

            Delete(city);
        }
    }
}
