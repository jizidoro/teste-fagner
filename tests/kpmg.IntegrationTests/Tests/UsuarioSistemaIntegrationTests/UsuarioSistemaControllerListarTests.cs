#region

using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos.UsuarioSistemaDtos;
using kpmg.Infrastructure.DataAccess;
using kpmg.UnitTests.Helpers;
using kpmg.UnitTests.Tests.UsuarioSistemaTests.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace kpmg.IntegrationTests.Tests.UsuarioSistemaIntegrationTests
{
    public class UsuarioSistemaControllerListarTests
    {
        private readonly UsuarioSistemaInjectionController _usuarioSistemaInjectionController = new();

        [Fact]
        public async Task UsuarioSistemaController_Listar()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_Listar_usuario_sistema")
                .Options;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var usuarioSistemaController = _usuarioSistemaInjectionController.ObterUsuarioSistemaController(context);
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
    }
}