#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaTipoCargoConfiguration : IEntityTypeConfiguration<BaTipoCargo>
    {
        public void Configure(EntityTypeBuilder<BaTipoCargo> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_TIPO_CARGO").IsRequired();
            builder.HasKey(c => c.Id);

            builder.HasOne(d => d.BaUsu)
                .WithMany(p => p.BaTipoCargos)
                .HasForeignKey(d => d.IdUsu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_TIPO_CLIENTE_ID_USU");
        }
    }
}