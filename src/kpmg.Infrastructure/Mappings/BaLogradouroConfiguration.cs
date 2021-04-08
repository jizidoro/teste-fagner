#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaLogradouroConfiguration : IEntityTypeConfiguration<BaLogradouro>
    {
        public void Configure(EntityTypeBuilder<BaLogradouro> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_LOGRADOURO").IsRequired();
            builder.HasKey(c => c.Id).HasName("PK_DML_BA_LOGRADOURO_ID_LOGRADOURO");
            ;

            builder.HasOne(d => d.BaUsu)
                .WithMany(p => p.BaLogradouros)
                .HasForeignKey(d => d.IdUsu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_LOGRADOURO_ID_USU");
        }
    }
}