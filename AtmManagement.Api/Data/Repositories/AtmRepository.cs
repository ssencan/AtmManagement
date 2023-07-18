using AtmManagement.Api.Dtos;
using AtmManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtmManagement.Api.Data.Repositories
{
    public class AtmRepository : Repository<Atm>, IAtmRepository
    {
        public AtmRepository(AtmDbContext context) : base(context)
        {
        }
        private AtmDbContext AtmDbContext
        {
            get { return _context as AtmDbContext; }
        }
        public async Task<IEnumerable<AtmDto>> GetAllAtm()
        {
            var query = from atm in AtmDbContext.Atms
                        join city in AtmDbContext.Cities on atm.CityID equals city.ID
                        join district in AtmDbContext.Districts on atm.DistrictID equals district.ID
                        select new AtmDto
                        {
                            Id = atm.ID,
                            AtmName = atm.AtmName,
                            Latitude = atm.Latitude,
                            Longitude = atm.Longitude,
                            IsActive = atm.IsActive,
                            CityID = atm.CityID,
                            CityName = city.CityName,
                            DistrictName = district.DistrictName,
                            DistrictID = atm.DistrictID
                        };
            return await query.ToListAsync();
        }

        public async Task<AtmDto> GetAtmById(int id)
        {
            var query = from atm in AtmDbContext.Atms
                        join city in AtmDbContext.Cities on atm.CityID equals city.ID
                        join district in AtmDbContext.Districts on atm.DistrictID equals district.ID
                        select new AtmDto
                        {
                            Id = atm.ID,
                            AtmName = atm.AtmName,
                            Latitude = atm.Latitude,
                            Longitude = atm.Longitude,
                            IsActive = atm.IsActive,
                            CityID = atm.CityID,
                            CityName = city.CityName,
                            DistrictName = district.DistrictName,
                            DistrictID = atm.DistrictID
                        };

            return await query.FirstOrDefaultAsync(x=>x.Id == id);
        }

        // Atm-specific methods can be added here
    }

}
