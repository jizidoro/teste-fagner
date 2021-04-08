#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class AirplaneConfiguration : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Codigo).HasMaxLength(255).IsRequired();
            builder.Property(c => c.Modelo).HasMaxLength(255).IsRequired();
            builder.Property(c => c.QuantidadePassageiros).IsRequired();
            builder.Property(c => c.DataRegistro).IsRequired();

            builder.HasIndex(c => c.Codigo).HasDatabaseName("IX_Airplanes_Codigo").IsUnique();
        }
    }
}