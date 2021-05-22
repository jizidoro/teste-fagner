#region

using System.Threading.Tasks;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;
using kpmg.UnitTests.Tests.UsuarioSistemaTests.Bases;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace kpmg.IntegrationTests.Tests.UsuarioSistemaIntegrationTests
{
    public class UsuarioSistemaControllerExcluirTests
    {
        private readonly UsuarioSistemaInjectionController _usuarioSistemaInjectionController = new();

        [Fact]
        public async Task UsuarioSistemaController_Excluir()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_Excluir_usuario_sistema")
                .Options;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var usuarioSistemaController = _usuarioSistemaInjectionController.ObterUsuarioSistemaController(context);
            _ = await usuarioSistemaController.Excluir(1);

            var respository = new UsuarioSistemaRepository(context);
            var usuario = await respository.GetById(1);
            Assert.Null(usuario);
        }
    }
}