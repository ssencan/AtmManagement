using AtmManagement.Api.Entities;
namespace AtmManagement.Api.Data.Repositories
{
    public class DistrictRepository : Repository<District>, IRepository<District>
    {
        public DistrictRepository(AtmDbContext context) : base(context)
        {
        }

        // District-specific methods can be added here
    }

}
