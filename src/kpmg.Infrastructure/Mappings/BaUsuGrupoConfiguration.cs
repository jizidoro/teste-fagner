#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaUsuGrupoConfiguration : IEntityTypeConfiguration<BaUsuGrupo>
    {
        public void Configure(EntityTypeBuilder<BaUsuGrupo> builder)
        {
            builder.HasKey(c => new {c.IdGrupoUsu, c.IdUsu});
        }
    }
}