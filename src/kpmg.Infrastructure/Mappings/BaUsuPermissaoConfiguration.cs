#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaUsuPermissaoConfiguration : IEntityTypeConfiguration<BaUsuPermissao>
    {
        public void Configure(EntityTypeBuilder<BaUsuPermissao> builder)
        {
            builder.HasKey(c => new {c.IdModulo, c.IdPermissao, c.IdTela, c.IdUsu});

            builder.HasOne(d => d.BaModulo)
                .WithMany(p => p.BaUsuPermissoes)
                .HasForeignKey(d => d.IdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_USU_PERMISSAO_DML_BA_MODULO");

            builder.HasOne(d => d.BaPermissao)
                .WithMany(p => p.BaUsuPermissoes)
                .HasForeignKey(d => d.IdPermissao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_USU_PERMISSAO_DML_BA_PERMISSAO");

            builder.HasOne(d => d.BaTela)
                .WithMany(p => p.BaUsuPermissoes)
                .HasForeignKey(d => d.IdTela)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_USU_PERMISSAO_DML_BA_TELA");

            builder.HasOne(d => d.BaUsu)
                .WithMany(p => p.BaUsuPermissoes)
                .HasForeignKey(d => d.IdUsu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_USU_PERMISSAO_DML_BA_USU");
        }
    }
}