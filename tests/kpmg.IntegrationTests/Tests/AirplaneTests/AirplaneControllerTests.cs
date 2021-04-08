#region

using System.Linq;
using System.Threading.Tasks;
using kpmg.Application.Dtos;
using kpmg.Application.Services;
using kpmg.Core.AirplaneCore.Usecase;
using kpmg.Core.AirplaneCore.Validation;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.WebApi.UseCases.V1.AirplaneApi;
using kpmg.IntegrationTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace kpmg.IntegrationTests.Tests.AirplaneTests
{
    public sealed class AirplaneControllerTests
    {
        private AirplaneController ObterAirplaneController(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var airplaneRepository = new AirplaneRepository(context);
            var airplaneValidarCodigoRepetido = new AirplaneValidarCodigoRepetido(airplaneRepository);
            var airplaneValidarEditar =
                new AirplaneValidarEditar(airplaneRepository, airplaneValidarCodigoRepetido);
            var airplaneValidarExcluir = new AirplaneValidarExcluir(airplaneRepository);
            var airplaneValidarIncluir =
                new AirplaneValidarIncluir(airplaneRepository, airplaneValidarCodigoRepetido);
            var airplaneIncluirUsecase = new AirplaneIncluirUsecase(airplaneRepository, airplaneValidarIncluir, uow);
            var airplaneExcluirUsecase = new AirplaneExcluirUsecase(airplaneRepository, airplaneValidarExcluir, uow);
            var airplaneEditarUsecase = new AirplaneEditarUsecase(airplaneRepository, airplaneValidarEditar, uow);
            var mapper = MapperHelper.ConfigMapper();

            var airplaneAppService = new AirplaneAppService(airplaneRepository, airplaneEditarUsecase,
                airplaneIncluirUsecase,
                airplaneExcluirUsecase, mapper);

            return new AirplaneController(airplaneAppService, mapper);
        }


        [Fact]
        public async Task Incluir_ChangesDatabase()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database_airplane")
                .Options;


            var teste = new AirplaneIncluirDto
            {
                Codigo = "123",
                Modelo = "234",
                QuantidadePassageiros = 456
            };

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            var airplaneController = ObterAirplaneController(context);
            _ = await airplaneController.Incluir(teste);
            Assert.Equal(1, context.Airplanes.Count());
        }

        [Fact]
        public async Task Get_ReturnsAirplane()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_airplane")
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