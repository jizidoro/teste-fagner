#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaModulosPermissaoConfiguration : IEntityTypeConfiguration<BaModulosPermissao>
    {
        public void Configure(EntityTypeBuilder<BaModulosPermissao> builder)
        {
            builder.HasKey(c => new {c.IdModulo, c.IdTela, c.IdPermissao});


            builder.HasOne(c => c.BaModulo)
                .WithMany(p => p.BaModulosPermissoes)
                .HasForeignKey(c => c.IdModulo);

            builder.HasOne(c => c.BaTela)
                .WithMany(p => p.BaModulosPermissoes)
                .HasForeignKey(c => c.IdTela);

            builder.HasOne(c => c.BaPermissao)
                .WithMany(p => p.BaModulosPermissoes)
                .HasForeignKey(c => c.IdPermissao);
        }
    }
}