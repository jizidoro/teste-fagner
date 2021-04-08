#region

using System.Linq;
using System.Threading.Tasks;
using kpmg.Application.Dtos;
using kpmg.Application.Services;
using kpmg.Core.BaUsuCore.Usecase;
using kpmg.Core.BaUsuCore.Validation;
using kpmg.Core.Helpers.Extensions;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.WebApi.UseCases.V1.BaUsuApi;
using kpmg.IntegrationTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace kpmg.IntegrationTests.Tests.BaUsuTests
{
    public sealed class BaUsuControllerTests
    {
        private readonly ITestOutputHelper _output;

        public BaUsuControllerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private BaUsuController ObterBaUsuController(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var baUsuRepository = new BaUsuRepository(context);

            var baUsuValidarEditar =
                new BaUsuValidarEditar(baUsuRepository);
            var baUsuValidarExcluir = new BaUsuValidarExcluir(baUsuRepository);
            var baUsuValidarIncluir =
                new BaUsuValidarIncluir(baUsuRepository);
            var baUsuIncluirUsecase = new BaUsuIncluirUsecase(baUsuRepository, baUsuValidarIncluir, uow);
            var baUsuExcluirUsecase = new BaUsuExcluirUsecase(baUsuRepository, baUsuValidarExcluir, uow);
            var baUsuEditarUsecase = new BaUsuEditarUsecase(baUsuRepository, baUsuValidarEditar, uow);
            var mapper = MapperHelper.ConfigMapper();

            var baUsuAppService = new BaUsuAppService(baUsuRepository, baUsuEditarUsecase, baUsuIncluirUsecase,
                baUsuExcluirUsecase, mapper);

            return new BaUsuController(baUsuAppService, mapper);
        }


        [Fact]
        public async Task Incluir_ChangesDatabase()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database_baUsu")
                .Options;


            var teste = new BaUsuIncluirDto
            {
                Id = 20204,
                NomeUsu = "20204",
                Senha = "05852608777",
                IdLogradouro = 10,
                Cpf = "12345",
                NrLogradouro = 12345,
                StsUsu = 1,
                CodCargo = 2,
                DtAdmissao = HorariosFusoExtensions.ObterHorarioBrasilia(),
                Matricula = "123456",
                IdUsuCad = 12345,
                DtCad = HorariosFusoExtensions.ObterHorarioBrasilia()
            };


            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            var baUsuController = ObterBaUsuController(context);
            _ = await baUsuController.Incluir(teste);
            Assert.Equal(1, context.BaUsus.Count());
        }

        [Fact]
        public async Task Get_ReturnsBaUsu()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_baUsu")
                .Options;

            BaUsu baUsu = null;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var repository = new BaUsuRepository(context);
            baUsu = await repository.GetById(20203);
            Assert.NotNull(baUsu);
        }
    }
}