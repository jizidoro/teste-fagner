#region

using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings
{
    public class BaGrupoUsuPermissaoConfiguration : IEntityTypeConfiguration<BaGrupoUsuPermissao>
    {
        public void Configure(EntityTypeBuilder<BaGrupoUsuPermissao> builder)
        {
            builder.HasKey(c => new {c.IdGrupoUsu, c.IdModulo, c.IdPermissao, c.IdTela});

            builder.HasOne(d => d.BaGrupoUsu)
                .WithMany(p => p.BaGrupoUsuPermissoes)
                .HasForeignKey(d => d.IdGrupoUsu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_GRUPO_USU_PERMISSAO_DML_BA_GRUPO_USU");

            builder.HasOne(d => d.BaModulo)
                .WithMany(p => p.BaGrupoUsuPermissoes)
                .HasForeignKey(d => d.IdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_GRUPO_USU_PERMISSAO_DML_BA_MODULO");

            builder.HasOne(d => d.BaPermissao)
                .WithMany(p => p.BaGrupoUsuPermissoes)
                .HasForeignKey(d => d.IdPermissao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_GRUPO_USU_PERMISSAO_DML_BA_PERMISSAO");

            builder.HasOne(d => d.BaTela)
                .WithMany(p => p.BaGrupoUsuPermissoes)
                .HasForeignKey(d => d.IdTela)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DML_BA_GRUPO_USU_PERMISSAO_DML_BA_TELA");
        }
    }
}