#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaUsuConfiguration : IEntityTypeConfiguration<BaUsu>
    {
        public void Configure(EntityTypeBuilder<BaUsu> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_USU").IsRequired();
            builder.HasKey(c => c.Id).HasName("PK_DML_BA_USU_ID_USU");


            builder.HasOne(d => d.BaLogradouro)
                .WithMany(p => p.BaUsus)
                .HasForeignKey(d => d.IdLogradouro)
                .HasConstraintName("FK_DML_BA_USU_ID_LOGRADOURO");
        }
    }
}