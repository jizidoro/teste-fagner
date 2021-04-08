#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaCargoConfiguration : IEntityTypeConfiguration<BaCargo>
    {
        public void Configure(EntityTypeBuilder<BaCargo> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_CARGO").IsRequired();
            builder.HasKey(c => c.Id);

            builder.HasOne(d => d.BaUsu)
                .WithMany(p => p.BaCargos)
                .HasForeignKey(d => d.IdUsu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_CARGO_ID_USU");

            builder.HasOne(d => d.BaTipoCargo)
                .WithMany(p => p.BaCargos)
                .HasForeignKey(d => d.TipoCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_CARGO_TIPO");
        }
    }
}