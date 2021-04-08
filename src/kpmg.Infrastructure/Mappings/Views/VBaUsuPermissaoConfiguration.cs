#region

using kpmg.Domain.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace kpmg.Infrastructure.Mappings.Views
{
    public class VBaUsuPermissaoConfiguration : IEntityTypeConfiguration<VBaUsuPermissao>
    {
        public void Configure(EntityTypeBuilder<VBaUsuPermissao> builder)
        {
            builder.ToView("V_DML_BA_USU_PERMISSAO").HasNoKey();

            builder.Property(b => b.IdUsu).HasColumnName("ID_USU");
            builder.Property(c => c.GrupoUsu).HasColumnName("ID_GRUPO_USU");
            builder.Property(c => c.Adm).HasColumnName("ADM");
            builder.Property(c => c.Modulo).HasColumnName("ID_MODULO");
            builder.Property(c => c.Tela).HasColumnName("ID_TELA");
            builder.Property(c => c.Permissao).HasColumnName("ID_PERMISSAO");
        }
    }
}