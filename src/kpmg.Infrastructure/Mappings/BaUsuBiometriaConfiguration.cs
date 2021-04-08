#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaUsuBiometriaConfiguration : IEntityTypeConfiguration<BaUsuBiometria>
    {
        public void Configure(EntityTypeBuilder<BaUsuBiometria> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_BIOMETRIA").IsRequired();
            builder.HasKey(c => c.Id);
        }
    }
}