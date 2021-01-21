using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckApp.Domain.Entities;

namespace TruckApp.Data.Mapping
{
    public class TruckMapping: IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Trucks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Modelo).IsRequired();
            builder.Property(x => x.AnoFabricacao).IsRequired();
            builder.Property(x => x.AnoModelo).IsRequired();
        }
    }
}