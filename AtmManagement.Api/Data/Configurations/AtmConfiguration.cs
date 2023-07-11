using AtmManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtmManagement.Api.Data.Configurations
{
    public class AtmConfiguration : IEntityTypeConfiguration<Atm>
    {
        public void Configure(EntityTypeBuilder<Atm> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AtmName).HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.CityID).IsRequired();
            builder.Property(x => x.DistrictID).IsRequired();

            builder
                .HasOne(a => a.City)
                .WithMany(c => c.Atms)
                .HasForeignKey(a => a.CityID)
                .OnDelete(DeleteBehavior.NoAction);  // Cascade delete for City is off

            builder
                .HasOne(a => a.District)
                .WithMany(d => d.Atms)
                .HasForeignKey(a => a.DistrictID)
                .OnDelete(DeleteBehavior.NoAction);  // Cascade delete for District is off



            builder
                .ToTable("Atm");
        }
    }
}
