#region

using kpmg.Domain.Models;
using kpmg.Domain.Models.Views;
using kpmg.Infrastructure.Mappings;
using kpmg.Infrastructure.Mappings.Views;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Infrastructure.DataAccess
{
    public class KpmgContext : DbContext
    {
        private const string JsonPath = "kpmg.Infrastructure.SeedData";

        public KpmgContext(DbContextOptions<KpmgContext> options)
            : base(options)
        {
        }

        // Tabelas
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<BaCargo> BaCargos { get; set; }
        public DbSet<BaFilial> BaFiliais { get; set; }
        public DbSet<BaGrupoUsu> BaGrupoUsus { get; set; }
        public DbSet<BaGrupoUsuPermissao> BaGrupoUsuPermissoes { get; set; }
        public DbSet<BaLogradouro> BaLogradouros { get; set; }
        public DbSet<BaModulo> BaModulos { get; set; }
        public DbSet<BaModulosPermissao> BaModulosPermissoes { get; set; }
        public DbSet<BaParam> BaParams { get; set; }
        public DbSet<BaPermissao> BaPermissoes { get; set; }
        public DbSet<BaTela> BaTelas { get; set; }
        public DbSet<BaTipoCargo> BaTipoCargos { get; set; }
        public DbSet<BaUsu> BaUsus { get; set; }
        public DbSet<BaUsuFilial> BaUsuFiliais { get; set; }
        public DbSet<BaUsuPermissao> BaUsuPermissoes { get; set; }

        // Views
        public DbSet<VBaUsuPermissao> VBaUsuPermissoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabelas
            modelBuilder.ApplyConfiguration(new AirplaneConfiguration());
            modelBuilder.ApplyConfiguration(new BaCargoConfiguration());
            modelBuilder.ApplyConfiguration(new BaFilialConfiguration());
            modelBuilder.ApplyConfiguration(new BaGrupoUsuConfiguration());
            modelBuilder.ApplyConfiguration(new BaGrupoUsuPermissaoConfiguration());
            modelBuilder.ApplyConfiguration(new BaLogradouroConfiguration());
            modelBuilder.ApplyConfiguration(new BaModuloConfiguration());
            modelBuilder.ApplyConfiguration(new BaModulosPermissaoConfiguration());
            modelBuilder.ApplyConfiguration(new BaParamConfiguration());
            modelBuilder.ApplyConfiguration(new BaPermissaoConfiguration());
            modelBuilder.ApplyConfiguration(new BaTelaConfiguration());
            modelBuilder.ApplyConfiguration(new BaTipoCargoConfiguration());
            modelBuilder.ApplyConfiguration(new BaUsuConfiguration());
            modelBuilder.ApplyConfiguration(new BaUsuFilialConfiguration());
            modelBuilder.ApplyConfiguration(new BaUsuPermissaoConfiguration());

            // Views
            modelBuilder.ApplyConfiguration(new VBaUsuPermissaoConfiguration());
        }
    }
}