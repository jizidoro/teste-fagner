#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaUsuFilialConfiguration : IEntityTypeConfiguration<BaUsuFilial>
    {
        public void Configure(EntityTypeBuilder<BaUsuFilial> builder)
        {
            builder.HasKey(c => new {c.IdUsu, c.IdFilial});

            builder.HasOne(c => c.BaFilial)
                .WithMany(p => p.BaUsuFiliais)
                .HasForeignKey(c => c.IdFilial)
                .HasConstraintName("FK_DML_BA_USU_FILIAL_DML_BA_FILIAL");

            builder.HasOne(c => c.BaUsu)
                .WithMany(p => p.BaUsuFiliais)
                .HasForeignKey(c => c.IdUsu)
                .HasConstraintName("FK_DML_BA_USU_FILIAL_DML_BA_USU");
        }
    }
}