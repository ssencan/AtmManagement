using AtmManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtmManagement.Api.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.ID);//Tablonun anahtar alanını (primary key) belirtir.
            builder.Property(x => x.CityName).HasMaxLength(100).IsUnicode(false); //Property ile Tablo içindeki her bir özelliği yapılandırır.
            builder.Property(x => x.PlateNumber).IsRequired();

            builder
                .ToTable("City");
        }
    }
}
