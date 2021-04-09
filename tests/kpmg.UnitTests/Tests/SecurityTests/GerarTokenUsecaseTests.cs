#region

using System.Linq;
using System.Threading.Tasks;
using kpmg.Application.Dtos;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;
using kpmg.UnitTests.Tests.BaUsuTests.Bases;
using kpmg.UnitTests.Tests.BaUsuTests.TestDatas;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace kpmg.UnitTests.Tests.SecurityTests
{
    public sealed class GerarTokenUsecaseTests

    {
        private readonly AutenticacaoInjectionUseCase _autenticacaoInjectionUseCase = new();
        private readonly ITestOutputHelper _output;

        public GerarTokenUsecaseTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [ClassData(typeof(AutenticacaoDtoTestData))]
        public async Task Get_ReturnsGerarToken(
            int expected, AutenticacaoDto testeEntrada)
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database")
                .Options;
            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);


            var repository = new UsuarioSistemaRepository(context);

            var obterGerarTokenLoginUsecase =
                _autenticacaoInjectionUseCase.ObterGerarTokenLoginUsecase(context);
            var result = await obterGerarTokenLoginUsecase.Execute(testeEntrada.Chave, testeEntrada.Senha);
            Assert.Equal(expected,result.ErrorCode);
        }
    }
}