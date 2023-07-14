using AtmManagement.Api.Entities;
namespace AtmManagement.Api.Data.Repositories
{
    public class AtmRepository : BaseRepository<Atm>, IRepository<Atm>
    {
        public AtmRepository(AtmDbContext context) : base(context)
        {
        }

        // Atm-specific methods can be added here
    }

}
