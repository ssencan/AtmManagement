using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtmManagement.Api.Data.Repositories
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(AtmDbContext context) : base(context)
        {
        }

        private AtmDbContext AtmDbContext
        {
            get { return _context as AtmDbContext; }
        }

        public async Task<IEnumerable<DistrictDto>> GetAllDistrict()
        {
            var query = from district in AtmDbContext.Districts
                        join city in AtmDbContext.Cities on district.CityID equals city.ID
                        select new DistrictDto
                        {
                            Id = district.ID,
                            Name = district.DistrictName,
                            CityId = district.CityID,
                            CityName = city.CityName
                        };
            return await query.ToListAsync();
        }

        public async Task<DistrictDto> GetDistrictById(int id)
        {
            var query = from district in AtmDbContext.Districts 
                        join city in AtmDbContext.Cities on district.CityID equals city.ID
                        select new DistrictDto
                        {
                            Id = district.ID,
                            Name = district.DistrictName,
                            CityId = district.CityID,
                            CityName = city.CityName
                        };

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
