#region

using System.Linq;
using System.Threading.Tasks;
using kpmg.Application.Dtos;
using kpmg.Application.Services;
using kpmg.Core.Helpers.Extensions;
using kpmg.Core.UsuarioSistemaCore.Usecase;
using kpmg.Core.UsuarioSistemaCore.Validation;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.IntegrationTests.Helpers;
using kpmg.WebApi.UseCases.V1.UsuarioSistemaApi;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace kpmg.IntegrationTests.Tests.BaUsuTests
{
    public sealed class UsuarioSistemaControllerTests
    {
        private readonly ITestOutputHelper _output;

        public UsuarioSistemaControllerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private UsuarioSistemaController ObterUsuarioSistemaController(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var usuarioSistemaRepository = new UsuarioSistemaRepository(context);

            var usuarioSistemaValidarEditar =
                new UsuarioSistemaValidarEditar(usuarioSistemaRepository);
            var usuarioSistemaValidarExcluir = new UsuarioSistemaValidarExcluir(usuarioSistemaRepository);
            var usuarioSistemaValidarIncluir =
                new UsuarioSistemaValidarIncluir(usuarioSistemaRepository);
            var usuarioSistemaIncluirUsecase = new UsuarioSistemaIncluirUsecase(usuarioSistemaRepository, usuarioSistemaValidarIncluir, uow);
            var usuarioSistemaExcluirUsecase = new UsuarioSistemaExcluirUsecase(usuarioSistemaRepository, usuarioSistemaValidarExcluir, uow);
            var usuarioSistemaEditarUsecase = new UsuarioSistemaEditarUsecase(usuarioSistemaRepository, usuarioSistemaValidarEditar, uow);
            var mapper = MapperHelper.ConfigMapper();

            var usuarioSistemaAppService = new UsuarioSistemaAppService(usuarioSistemaRepository, usuarioSistemaEditarUsecase, usuarioSistemaIncluirUsecase,
                usuarioSistemaExcluirUsecase, mapper);

            return new UsuarioSistemaController(usuarioSistemaAppService, mapper);
        }


        [Fact]
        public async Task Incluir_ChangesDatabase()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database_usuarioSistema")
                .Options;


            var teste = new UsuarioSistemaIncluirDto
            {
                Id = 20204,
                Nome = "20204",
                Senha = "05852608777",
                Matricula = "123456",
            };


            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            var usuarioSistemaController = ObterUsuarioSistemaController(context);
            _ = await usuarioSistemaController.Incluir(teste);
            Assert.Equal(1, context.UsuarioSistemas.Count());
        }

        [Fact]
        public async Task Get_ReturnsUsuarioSistema()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_usuarioSistema")
                .Options;

            UsuarioSistema usuarioSistema = null;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var repository = new UsuarioSistemaRepository(context);
            usuarioSistema = await repository.GetById(20203);
            Assert.NotNull(usuarioSistema);
        }
    }
}