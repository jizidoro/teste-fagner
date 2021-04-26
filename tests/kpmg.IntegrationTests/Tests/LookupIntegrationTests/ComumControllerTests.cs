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
        private readonly ObterServiceProviderDb _obterServiceProviderDb = new();
        private readonly ObterServiceProviderMemDb _obterServiceProviderMemDb = new();

        public ComumControllerTests(ITestOutputHelper output)
        {
            _output = output;
        }


        private ComumController ObterComumControllerDb()
        {
            var mapper = MapperHelper.ConfigMapper();

            var serviceProvider = _obterServiceProviderDb.Execute();

            var context = serviceProvider.GetService<KpmgContext>();

            var baUsuAppService = _usuarioSistemaInjectionAppService.ObterUsuarioSistemaAppService(context, mapper);

            return new ComumController(serviceProvider, baUsuAppService);
        }

        private ComumController ObterComumControllerMemDb()
        {
            var mapper = MapperHelper.ConfigMapper();

            var serviceProvider = _obterServiceProviderMemDb.Execute();

            var context = serviceProvider.GetService<KpmgContext>();

            var baUsuAppService = _usuarioSistemaInjectionAppService.ObterUsuarioSistemaAppService(context, mapper);

            return new ComumController(serviceProvider, baUsuAppService);
        }

        [Fact(Skip = "usa a instancia local do sqlserver")]
        public async Task GetLookupUsuarioSistemaDb_Test()
        {
            var comumController = ObterComumControllerDb();
            var result = await comumController.GetLookupUsuarioSistema();

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as ListResultDto<LookupDto>;
                Assert.NotNull(actualResultValue);
            }
        }

        [Fact]
        public async Task GetLookupUsuarioSistemaMemDb_Test()
        {
            var comumController = ObterComumControllerMemDb();
            var result = await comumController.GetLookupUsuarioSistema();

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as ListResultDto<LookupDto>;
                Assert.NotNull(actualResultValue);
            }
        }
    }
}