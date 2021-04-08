#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaUsuRedeConfiguration : IEntityTypeConfiguration<BaUsuRede>
    {
        public void Configure(EntityTypeBuilder<BaUsuRede> builder)
        {
            builder.HasKey(c => new {c.IdRede, c.IdUsu});
        }
    }
}