#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaFilialConfiguration : IEntityTypeConfiguration<BaFilial>
    {
        public void Configure(EntityTypeBuilder<BaFilial> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_FILIAL").IsRequired();
            builder.HasKey(c => c.Id);

            builder.HasOne(d => d.BaLogradouro)
                .WithMany(p => p.BaFiliais)
                .HasForeignKey(d => d.IdLogradouro)
                .HasConstraintName("FK_DML_BA_FILIAL_ID_LOGRADOURO");

            builder.HasOne(d => d.BaUsu)
                .WithMany(p => p.BaFiliais)
                .HasForeignKey(d => d.IdUsu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_FILIAL_ID_USU");
        }
    }
}