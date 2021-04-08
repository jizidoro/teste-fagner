#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaPermissaoConfiguration : IEntityTypeConfiguration<BaPermissao>
    {
        public void Configure(EntityTypeBuilder<BaPermissao> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_PERMISSAO").IsRequired();
            builder.HasKey(c => c.Id);
        }
    }
}