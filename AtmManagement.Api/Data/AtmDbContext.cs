using Microsoft.EntityFrameworkCore;
using AtmManagement.Api.Entities;
using AtmManagement.Api.Data.Configurations;

namespace AtmManagement.Api.Data
{
    public class AtmDbContext : DbContext
    {
        public AtmDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Atm> Atms { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AtmConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
        }
    }
}
