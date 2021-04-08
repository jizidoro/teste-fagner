#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaUsuGrupoEconomicoConfiguration : IEntityTypeConfiguration<BaUsuGrupoEconomico>
    {
        public void Configure(EntityTypeBuilder<BaUsuGrupoEconomico> builder)
        {
            builder.HasKey(c => new {c.IdGrupoEconomico, c.IdUsu});
        }
    }
}