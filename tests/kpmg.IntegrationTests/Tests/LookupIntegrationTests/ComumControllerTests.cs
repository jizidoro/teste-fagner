#region

using System.Collections.Generic;
using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Interfaces;
using kpmg.Application.Services;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Infrastructure.Bases;
using kpmg.Infrastructure.DataAccess;
using kpmg.IntegrationTests.Helpers;
using kpmg.UnitTests.Tests.UsuarioSistemaTests.Bases;
using kpmg.WebApi.Modules;
using kpmg.WebApi.Modules.Common;
using kpmg.WebApi.Modules.Common.FeatureFlags;
using kpmg.WebApi.Modules.Common.Swagger;
using kpmg.WebApi.UseCases.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace kpmg.IntegrationTests.Tests.LookupIntegrationTests
{
    public sealed class ComumControllerTests
    {
        private readonly ITestOutputHelper _output;
        private readonly UsuarioSistemaInjectionAppService _usuarioSistemaInjectionAppService = new();

        public ComumControllerTests(ITestOutputHelper output)
        {
            _output = output;
        }


        private ComumController ObterComumController(KpmgContext context)
        {
            var mapper = MapperHelper.ConfigMapper();
            var baUsuAppService = _usuarioSistemaInjectionAppService.ObterUsuarioSistemaAppService(context, mapper);

            var services = new ServiceCollection();

            var inMemorySettings = new Dictionary<string, string>
            {
                {"TopLevelKey", "TopLevelValue"},
                {
                    "PersistenceModule:DefaultConnection",
                    "Server=(localdb)\\mssqllocaldb;Database=BD_KPMG_TESTE;Trusted_Connection=True;MultipleActiveResultSets=true"
                }
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            services
                .AddFeatureFlags(configuration)
                .AddInvalidRequestLogging()
                .AddSqlServer(configuration)
                .AddHealthChecks(configuration)
                .AddAuthentication(configuration)
                .AddVersioning()
                .AddSwagger()
                .AddUseCases()
                .AddCustomControllers()
                .AddCustomCors()
                .AddProxy()
                .AddCustomDataProtection();

            services.AddAutoMapperSetup();

            services.AddScoped(typeof(ILookupServiceApp<>), typeof(LookupServiceApp<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );

            // Create the service provider instance
            var serviceProvider = services.BuildServiceProvider();

            return new ComumController(serviceProvider, baUsuAppService);
        }

        [Fact]
        public async Task GetLookupUsuarioSistema_Test()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_GetLookupUsuarioSistema_Test")
                .Options;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var comumController = ObterComumController(context);
            var result = await comumController.GetLookupUsuarioSistema();

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as ListResultDto<LookupDto>;
                Assert.NotNull(actualResultValue);
            }
        }
    }
}