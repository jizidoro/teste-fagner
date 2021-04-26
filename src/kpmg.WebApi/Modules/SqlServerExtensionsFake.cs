#region

using kpmg.Core.AirplaneCore;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.UsuarioSistemaCore;
using kpmg.Core.Views.VBaUsuPermissaoCore;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.Infrastructure.Repositories.Views;
using kpmg.WebApi.Modules.Common.FeatureFlags;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

#endregion

namespace kpmg.WebApi.Modules
{
    /// <summary>
    ///     Persistence Extensions.
    /// </summary>
    public static class SqlServerExtensionsFake
    {
        /// <summary>
        ///     Add Persistence dependencies varying on configuration.
        /// </summary>
        public static IServiceCollection AddSqlServerFake(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            IFeatureManager featureManager = services
                .BuildServiceProvider()
                .GetRequiredService<IFeatureManager>();

            var isEnabled = featureManager
                .IsEnabledAsync(nameof(CustomFeature.SqlServer))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();


            services.AddDbContext<KpmgContext>(
                options => options.UseInMemoryDatabase("test_database"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped<IUsuarioSistemaRepository, UsuarioSistemaRepository>();
            services.AddScoped<IVwUsuarioSistemaPermissaoRepository, VwUsuarioSistemaPermissaoRepository>();

            return services;
        }
    }
}