using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                        select new DistrictDto
                        {
                            Id = district.ID,
                            Name = district.DistrictName,
                            CityId = district.CityID
                        };
            return await query.ToListAsync();
        }

        public async Task<DistrictDto> GetDistrictById(int id)
        {
            var district = await GetByIdAsync(id);

            if (district == null)
                return null;

            var districtDto = new DistrictDto
            {
                Id = district.ID,
                Name = district.DistrictName,
                CityId = district.CityID
            };

            return districtDto;
        }
    }
}
