#region

using System.Threading.Tasks;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;
using kpmg.UnitTests.Tests.UsuarioSistemaTests.Bases;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace kpmg.IntegrationTests.Tests.UsuarioSistemaIntegrationTests
{
    public class UsuarioSistemaContextTests
    {
        private readonly UsuarioSistemaInjectionController _usuarioSistemaInjectionController = new();

        [Fact]
        public async Task UsuarioSistema_Context()
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
    }
}