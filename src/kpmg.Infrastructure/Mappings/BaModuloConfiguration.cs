#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaModuloConfiguration : IEntityTypeConfiguration<BaModulo>
    {
        public void Configure(EntityTypeBuilder<BaModulo> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_MODULO").IsRequired();
            builder.HasKey(c => c.Id);
        }
    }
}