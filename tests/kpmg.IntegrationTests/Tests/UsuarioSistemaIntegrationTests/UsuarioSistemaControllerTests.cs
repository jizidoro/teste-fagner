#region

using System.Linq;
using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos.UsuarioSistemaDtos;
using kpmg.Application.Queries;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.IntegrationTests.Helpers;
using kpmg.UnitTests.Tests.UsuarioSistemaTests.Bases;
using kpmg.WebApi.UseCases.V1.UsuarioSistemaApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace kpmg.IntegrationTests.Tests.UsuarioSistemaIntegrationTests
{
    public sealed class UsuarioSistemaControllerTests
    {
        private readonly ITestOutputHelper _output;

        private readonly UsuarioSistemaInjectionAppService _usuarioSistemaInjectionAppService = new();

        public UsuarioSistemaControllerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private UsuarioSistemaController ObterUsuarioSistemaController(KpmgContext context)
        {
            var mapper = MapperHelper.ConfigMapper();
            var usuarioSistemaAppService =
                _usuarioSistemaInjectionAppService.ObterUsuarioSistemaAppService(context, mapper);

            return new UsuarioSistemaController(usuarioSistemaAppService, mapper);
        }


        [Fact]
        public async Task Incluir_UsuarioSistema()
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
            var usuarioSistemaController = ObterUsuarioSistemaController(context);
            _ = await usuarioSistemaController.Incluir(teste);
            Assert.Equal(1, context.UsuarioSistemas.Count());
        }


        [Fact]
        public async Task Incluir_UsuarioSistema_Erro()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_incluir_usuario_sistema")
                .Options;


            var teste = new UsuarioSistemaIncluirDto {};


            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            var usuarioSistemaController = ObterUsuarioSistemaController(context);
            var result = await usuarioSistemaController.Incluir(teste);
            
            if (result is OkObjectResult okObjectResult)
            {   
                var actualResultValue = okObjectResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(400, actualResultValue.Codigo);
            }
            Assert.Equal(0, context.UsuarioSistemas.Count());
        }


        [Fact]
        public async Task Editar_UsuarioSistema()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_editar_usuario_sistema")
                .Options;

            var alteracaoNome = "Novo Nome";
            var alteracaoEmail = "novo@email.com";
            var alteracaoSenha = "NovaSenha";
            var alteracaoMatricula = "NovaMatricula";
            
            var teste = new UsuarioSistemaEditarDto
            {
                Id = 1,
                Nome = alteracaoNome,
                Email = alteracaoEmail,
                Senha = alteracaoSenha,
                Situacao = false,
                Matricula = alteracaoMatricula
            };
            
            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var usuarioSistemaController = ObterUsuarioSistemaController(context);
            var result = await usuarioSistemaController.Editar(teste);
            
            if (result is OkObjectResult okObjectResult)
            {   
                var actualResultValue = okObjectResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
            }
            
            var repository = new UsuarioSistemaRepository(context);
            var usuario = await repository.GetById(1);
            Assert.Equal(alteracaoNome, usuario.Nome);
            Assert.Equal(alteracaoEmail, usuario.Email);
            // Assert.Equal(alteracaoSenha, usuario.Senha);
            Assert.Equal(alteracaoMatricula, usuario.Matricula);
            Assert.False(usuario.Situacao);
        }
        
        [Fact]
        public async Task Editar_UsuarioSistema_Erro()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_editar_usuario_sistema_Erro")
                .Options;

            var alteracaoNome = "Novo Nome";
            var alteracaoEmail = "novo@email.com";
            var alteracaoSenha = "NovaSenha";
            var alteracaoMatricula = "NovaMatricula";
            
            var teste = new UsuarioSistemaEditarDto
            {
                Id = 1,
                Nome = alteracaoNome,
                Situacao = false,
            };
            
            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            
            var usuarioSistemaController = ObterUsuarioSistemaController(context);
            var result = await usuarioSistemaController.Editar(teste);
            
            if (result is OkObjectResult okObjectResult)
            {   
                var actualResultValue = okObjectResult.Value as SingleResultDto<EntityDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(400, actualResultValue.Codigo);
            }
            
            var repository = new UsuarioSistemaRepository(context);
            var usuario = await repository.GetById(1);
            Assert.NotEqual(alteracaoNome, usuario.Nome);
            Assert.NotEqual(alteracaoEmail, usuario.Email);
            // Assert.Equal(alteracaoSenha, usuario.Senha);
            Assert.NotEqual(alteracaoMatricula, usuario.Matricula);
            Assert.True(usuario.Situacao);
        }

        [Fact]
        public async Task Obter_UsuarioSistema_Repositorio()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_obter_usuario_sistema_Respositorio")
                .Options;

            UsuarioSistema usuarioSistema = null;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var repository = new UsuarioSistemaRepository(context);
            usuarioSistema = await repository.GetById(1);
            Assert.NotNull(usuarioSistema);
        }
        
        [Fact]
        public async Task Obter_UsuarioSistema_Controller()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_Obter_usuario_sistema_Controller")
                .Options;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            
            var usuarioSistemaController = ObterUsuarioSistemaController(context);
            var result = await usuarioSistemaController.Obter(1);
            
            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as SingleResultDto<UsuarioSistemaDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
                Assert.NotNull(actualResultValue.Data);
            }
        }
        
        [Fact]
        public async Task Listar_UsuarioSistema()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_Listar_usuario_sistema")
                .Options;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            
            var usuarioSistemaController = ObterUsuarioSistemaController(context);
            var result = await usuarioSistemaController.Listar(null);
            
            if (result is OkObjectResult okObjectResult)
            {   
                var actualResultValue = okObjectResult.Value as PageResultDto<UsuarioSistemaDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
                Assert.NotNull(actualResultValue.Data);
                Assert.Equal(4, actualResultValue.Data.Count);
            }
        }

        [Fact]
        public async Task Listar_UsuarioSistema_Paginado()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_Listar_usuario_sistema_Paginado")
                .Options;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            
            var usuarioSistemaController = ObterUsuarioSistemaController(context);
            var pagination = new PaginationQuery(1,3);
            var result = await usuarioSistemaController.Listar(pagination);
            
            if (result is OkObjectResult okObjectResult)
            {   
                var actualResultValue = okObjectResult.Value as PageResultDto<UsuarioSistemaDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
                Assert.NotNull(actualResultValue.Data);
                Assert.Equal(3, actualResultValue.Data.Count);
            }
        }

        [Fact]
        public async Task Excluir_UsuarioSistema()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_Excluir_usuario_sistema")
                .Options;
            
            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            
            var usuarioSistemaController = ObterUsuarioSistemaController(context);
           _ = await usuarioSistemaController.Excluir(1);

           var respository = new UsuarioSistemaRepository(context);
           var usuario = await respository.GetById(1);
           Assert.Null(usuario);
        }
    }
}