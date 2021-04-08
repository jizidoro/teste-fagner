#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaTelaConfiguration : IEntityTypeConfiguration<BaTela>
    {
        public void Configure(EntityTypeBuilder<BaTela> builder)
        {
            builder.Property(b => b.Id).HasColumnName("ID_TELA").IsRequired();
            builder.HasKey(c => c.Id);
        }
    }
}