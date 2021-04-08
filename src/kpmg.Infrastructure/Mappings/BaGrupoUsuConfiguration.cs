#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaGrupoUsuConfiguration : IEntityTypeConfiguration<BaGrupoUsu>
    {
        public void Configure(EntityTypeBuilder<BaGrupoUsu> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_GRUPO_USU").IsRequired();
            builder.HasKey(c => c.Id);
        }
    }
}