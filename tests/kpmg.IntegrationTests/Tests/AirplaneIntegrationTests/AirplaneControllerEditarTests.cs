﻿#region

using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos.AirplaneDtos;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;
using kpmg.UnitTests.Tests.AirplaneTests.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace kpmg.IntegrationTests.Tests.AirplaneIntegrationTests
{
    public class AirplaneControllerEditarTests
    {
        private readonly AirplaneInjectionController _airplaneInjectionController = new();

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
            var airplaneController = _airplaneInjectionController.ObterAirplaneController(context);
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
            var airplaneController = _airplaneInjectionController.ObterAirplaneController(context);
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
    }
}