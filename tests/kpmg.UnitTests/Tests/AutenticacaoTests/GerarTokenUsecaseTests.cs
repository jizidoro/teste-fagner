#region

using System.Threading.Tasks;
using kpmg.Application.Dtos;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;
using kpmg.UnitTests.Tests.AutenticacaoTests.Bases;
using kpmg.UnitTests.Tests.AutenticacaoTests.TestDatas;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace kpmg.UnitTests.Tests.AutenticacaoTests
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
        public async Task Test_GerarTokenLoginUsecase(int expected, AutenticacaoDto testeEntrada)
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_memoria_token" + testeEntrada.Chave)
                .Options;
            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var gerarTokenLoginUsecase = _autenticacaoInjectionUseCase.ObterGerarTokenLoginUsecase(context);
            var result = await gerarTokenLoginUsecase.Execute(testeEntrada.Chave, testeEntrada.Senha);
            Assert.Equal(expected, result.Code);
        }
    }
}