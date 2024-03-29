﻿#region

using kpmg.Application.Interfaces;
using kpmg.Application.Services;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Infrastructure.Bases;
using kpmg.Infrastructure.DataAccess;
using kpmg.WebApi.Modules;
using kpmg.WebApi.Modules.Common;
using kpmg.WebApi.Modules.Common.FeatureFlags;
using kpmg.WebApi.Modules.Common.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

#endregion

namespace kpmg.UnitTests.Helpers
{
    public class ObterServiceProviderMemDb
    {
        private readonly ContextFactory _contextFactory = new();

        public ServiceProvider Execute()
        {
            var services = new ServiceCollection();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            services
                .AddFeatureFlags(configuration)
                .AddInvalidRequestLogging()
                .AddSqlServerFake(configuration)
                .AddEntityRepository(configuration)
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
            return services.BuildServiceProvider();
        }
    }
}