#region

using System.Linq;
using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos.AirplaneDtos;
using kpmg.Application.Queries;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.IntegrationTests.Helpers;
using kpmg.UnitTests.Tests.AirplaneTests.Bases;
using kpmg.WebApi.UseCases.V1.AirplaneApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace kpmg.IntegrationTests.Tests.AirplaneIntegrationTests
{
    public sealed class AirplaneControllerTests
    {
        private readonly AirplaneInjectionAppService _airplaneInjectionAppService = new();

        private AirplaneController ObterAirplaneController(KpmgContext context)
        {
            var mapper = MapperHelper.ConfigMapper();

            var airplaneAppService = _airplaneInjectionAppService.ObterAirplaneAppService(context, mapper);

            return new AirplaneController(airplaneAppService, mapper);
        }


        [Fact]
        public async Task AirplaneController_Incluir()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database_AirplaneController_Incluir")
                .Options;


            var teste = new AirplaneIncluirDto
            {
                Codigo = "123",
                Modelo = "234",
                QuantidadePassageiro = 456
            };

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            var airplaneController = ObterAirplaneController(context);
            var result = await airplaneController.Incluir(teste);

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
            }

            Assert.Equal(1, context.Airplanes.Count());
        }

        [Fact]
        public async Task AirplaneController_Incluir_Erro()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database_AirplaneController_Incluir_Erro")
                .Options;


            var teste = new AirplaneIncluirDto
            {
                Codigo = "123",
                QuantidadePassageiro = 456
            };

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            var airplaneController = ObterAirplaneController(context);
            var result = await airplaneController.Incluir(teste);

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(400, actualResultValue.Codigo);
            }

            Assert.Equal(0, context.Airplanes.Count());
        }

        [Fact]
        public async Task AirplaneController_Editar()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database_AirplaneController_Editar")
                .Options;

            var alteracaoCodigo = "mudanca Codigo teste editar";
            var alteracaoModelo = "mudanca Modelo teste editar";

            var teste = new AirplaneEditarDto
            {
                Id = 1,
                Codigo = alteracaoCodigo,
                Modelo = alteracaoModelo,
                QuantidadePassageiro = 6666
            };

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var airplaneController = ObterAirplaneController(context);
            var result = await airplaneController.Editar(teste);

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
            }

            var repository = new AirplaneRepository(context);
            var airplane = await repository.GetById(1);
            Assert.Equal(6666, airplane.QuantidadePassageiro);
            Assert.Equal(alteracaoCodigo, airplane.Codigo);
            Assert.Equal(alteracaoModelo, airplane.Modelo);
        }

        [Fact]
        public async Task AirplaneController_Editar_Erro()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database_AirplaneController_Editar_Erro")
                .Options;

            var alteracaoCodigo = "mudanca Codigo teste editar";
            var alteracaoModelo = "mudanca Modelo teste editar";

            var teste = new AirplaneEditarDto
            {
                Id = 1,
                Codigo = alteracaoCodigo,
                QuantidadePassageiro = 6666
            };

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var airplaneController = ObterAirplaneController(context);
            var result = await airplaneController.Editar(teste);

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(400, actualResultValue.Codigo);
            }

            var repository = new AirplaneRepository(context);
            var airplane = await repository.GetById(1);
            Assert.NotEqual(6666, airplane.QuantidadePassageiro);
            Assert.NotEqual(alteracaoCodigo, airplane.Codigo);
            Assert.NotEqual(alteracaoModelo, airplane.Modelo);
        }

        [Fact]
        public async Task AirplaneController_Excluir()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_AirplaneController_Excluir")
                .Options;


            var idAirplane = 1;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var airplaneController = ObterAirplaneController(context);
            _ = await airplaneController.Excluir(idAirplane);

            var repository = new AirplaneRepository(context);
            var airplane = await repository.GetById(1);
            Assert.Null(airplane);
        }

        [Fact]
        public async Task AirplaneController_Obter()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_AirplaneController_Obter")
                .Options;


            var idAirplane = 1;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var airplaneController = ObterAirplaneController(context);
            var result = await airplaneController.Obter(idAirplane);

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as SingleResultDto<AirplaneDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
                Assert.NotNull(actualResultValue.Data);
            }
        }

        [Fact]
        public async Task AirplaneController_Listar()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_AirplaneController_Listar")
                .Options;


            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var airplaneController = ObterAirplaneController(context);
            var result = await airplaneController.Listar(null);

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as PageResultDto<AirplaneDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
                Assert.NotNull(actualResultValue.Data);
                Assert.Equal(3, actualResultValue.Data.Count);
            }
        }

        [Fact]
        public async Task AirplaneController_Listar_Paginado()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_AirplaneController_Listar_Paginado")
                .Options;


            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var airplaneController = ObterAirplaneController(context);
            var paginationQuery = new PaginationQuery();
            var result = await airplaneController.Listar(paginationQuery);

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as PageResultDto<AirplaneDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
                Assert.NotNull(actualResultValue.Data);
                Assert.Equal(3, actualResultValue.Data.Count);
            }
        }

        [Fact]
        public async Task Get_ReturnsAirplane()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_Get_ReturnsAirplane")
                .Options;

            Airplane airplane = null;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var repository = new AirplaneRepository(context);
            airplane = await repository.GetById(1);
            Assert.NotNull(airplane);
        }
    }
}