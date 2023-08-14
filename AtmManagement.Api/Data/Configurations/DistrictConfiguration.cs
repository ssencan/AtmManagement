using AtmManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtmManagement.Api.Data.Configurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.DistrictName).HasMaxLength(100).IsUnicode(false).IsRequired();
            builder.Property(x=>x.CityID).IsRequired();

            builder
                .HasOne(d => d.City) //HasOne ve WithMany: İlişkili tablolar arasındaki ilişkileri belirler. Örneğin, City sınıfı ile District sınıfı arasındaki ilişkiyi tanımlar.
                .WithMany(c => c.Districts)
                .HasForeignKey(d => d.CityID)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .ToTable("District");
        }
    }
}
