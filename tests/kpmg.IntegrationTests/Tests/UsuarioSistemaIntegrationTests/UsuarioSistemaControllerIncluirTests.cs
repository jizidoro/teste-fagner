#region

using System.Linq;
using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos.UsuarioSistemaDtos;
using kpmg.Application.Queries;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;
using kpmg.UnitTests.Tests.UsuarioSistemaTests.Bases;
using kpmg.WebApi.UseCases.V1.UsuarioSistemaApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace kpmg.IntegrationTests.Tests.UsuarioSistemaIntegrationTests
{
    public sealed class UsuarioSistemaControllerIncluirTests
    {
        private readonly UsuarioSistemaInjectionController _usuarioSistemaInjectionController = new();
        
        [Fact]
        public async Task UsuarioSistemaController_Incluir()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_incluir_usuario_sistema")
                .Options;


            var teste = new UsuarioSistemaIncluirDto
            {
                Id = 1,
                Nome = "111",
                Email = "777@teste",
                Senha = "123456",
                Situacao = true,
                Matricula = "123"
            };


            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            var usuarioSistemaController = _usuarioSistemaInjectionController.ObterUsuarioSistemaController(context);
            _ = await usuarioSistemaController.Incluir(teste);
            Assert.Equal(1, context.UsuarioSistemas.Count());
        }


        [Fact]
        public async Task UsuarioSistemaController_Incluir_Erro()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_incluir_usuario_sistema")
                .Options;


            var teste = new UsuarioSistemaIncluirDto();


            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            var usuarioSistemaController = _usuarioSistemaInjectionController.ObterUsuarioSistemaController(context);
            var result = await usuarioSistemaController.Incluir(teste);

            if (result is OkObjectResult okObjectResult)
            {
                var actualResultValue = okObjectResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(400, actualResultValue.Codigo);
            }

            Assert.Equal(0, context.UsuarioSistemas.Count());
        }






    }
}