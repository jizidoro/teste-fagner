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
        public DbSet<UsuarioSistema> UsuarioSistemas { get; set; }

        // Views
        public DbSet<VwUsuarioSistemaPermissao> VUsuarioSistemaPermissoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabelas
            modelBuilder.ApplyConfiguration(new AirplaneConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioSistemaConfiguration());

            // Views
            modelBuilder.ApplyConfiguration(new VwUsuarioSistemaPermissaoConfiguration());
        }
    }
}