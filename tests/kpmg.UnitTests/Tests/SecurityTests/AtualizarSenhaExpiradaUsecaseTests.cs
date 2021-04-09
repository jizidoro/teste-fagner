#region

using System.Linq;
using System.Threading.Tasks;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;
using kpmg.UnitTests.Tests.BaUsuTests.Bases;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace kpmg.UnitTests.Tests.SecurityTests
{
    public sealed class AtualizarSenhaExpiradaUsecaseTests
    {
        private readonly AutenticacaoInjectionUseCase _autenticacaoInjectionUseCase = new();
        private readonly ITestOutputHelper _output;

        public AtualizarSenhaExpiradaUsecaseTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task Editar_ChangesDatabase()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database")
                .Options;


            var teste = new UsuarioSistema
            {
                Id = 20203,
                // Chave = "20203",
                Senha = "123456"
            };

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var repository = new UsuarioSistemaRepository(context);
            var retornoAntes = await repository.GetById(20203);

            var obterAtualizarSenhaExpiradaUsecase =
                _autenticacaoInjectionUseCase.ObterAtualizarSenhaExpiradaUsecase(context);
            var result = await obterAtualizarSenhaExpiradaUsecase.Execute(teste);
            _output.WriteLine(result.Mensagem);

            var retornoDepois = await repository.GetById(20203);

            Assert.Equal(1, context.UsuarioSistemas.Count());
        }
    }
}