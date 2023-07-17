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

        public async Task<AtmDto> GetAtmById(int id)
        {
            var atm = await GetByIdAsync(id);

            if (atm == null)
                return null;

            var atmDto = new AtmDto
            {
                Id = atm.ID,
                AtmName = atm.AtmName,
                Latitude = atm.Latitude,
                Longitude = atm.Longitude,
                IsActive = atm.IsActive,
                CityID = atm.CityID,
                DistrictID = atm.DistrictID
            };

            return atmDto;
        }

        public async Task UpdateAtm(AtmDto atmDto)
        {
            var atm = await GetByIdAsync(atmDto.Id);

            if (atm == null)
                return;

            atm.AtmName = atmDto.AtmName;
            atm.Latitude = atmDto.Latitude;
            atm.Longitude = atmDto.Longitude;
            atm.IsActive = atmDto.IsActive;
            atm.CityID = atmDto.CityID;
            atm.DistrictID = atmDto.DistrictID;


            Update(atm);
        }

        public async Task AddAtm(AtmDto atmDto)
        {
            var atm = new Atm
            {
                AtmName = atmDto.AtmName,
                Latitude = atmDto.Latitude,
                Longitude = atmDto.Longitude,
                IsActive = atmDto.IsActive,
                CityID = atmDto.CityID,
                DistrictID = atmDto.DistrictID
            };

            Add(atm);
            await CommitAsync();
        }

        public async Task DeleteAtm(int id)
        {
            var atm = await GetByIdAsync(id);

            if (atm == null)
                return;

            Delete(atm);
           
        }

        // Atm-specific methods can be added here
    }

}
