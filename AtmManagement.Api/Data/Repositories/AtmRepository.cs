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
                        select new AtmDto
                        {
                            Id = atm.ID,
                            AtmName = atm.AtmName,
                            Latitude = atm.Latitude,
                            Longitude = atm.Longitude,
                            IsActive = atm.IsActive,
                            CityID = atm.CityID,
                            DistrictID = atm.DistrictID

                        };
            return await query.ToListAsync();
        }

        // Atm-specific methods can be added here
    }

}
