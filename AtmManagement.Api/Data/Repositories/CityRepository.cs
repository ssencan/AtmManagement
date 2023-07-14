using AtmManagement.Api.Entities;
namespace AtmManagement.Api.Data.Repositories
{
    public class CityRepository : BaseRepository<City>, IRepository<City>
    {
        public CityRepository(AtmDbContext context) : base(context)
        {
        }

        // City-specific methods can be added here
    }

}
