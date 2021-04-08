#region

using System.Threading.Tasks;
using kpmg.Application.Dtos;
using kpmg.Infrastructure.DataAccess;
using kpmg.UnitTests.Tests.BaUsuTests.Bases;
using kpmg.UnitTests.Tests.BaUsuTests.TestDatas;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace kpmg.UnitTests.Tests.SecurityTests
{
    public sealed class AutenticacaoAppServiceTests
    {
        private readonly AutenticacaoInjectionAppService _autenticacaoInjectionAppService =
            new();

        private readonly ITestOutputHelper _output;

        public AutenticacaoAppServiceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [ClassData(typeof(AutenticacaoDtoTestData))]
        public async Task Editar_ChangesDatabase(
            int expected, AutenticacaoDto testeEntrada)
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_change_database_contrato_verba")
                .Options;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            var autenticacaoAppService = _autenticacaoInjectionAppService.ObterAutenticacaoAppServiceService(context);
            var result = await autenticacaoAppService.GerarTokenLoginUsecase(testeEntrada);
            _output.WriteLine(result.Mensagem);
            Assert.Equal(expected, result.Codigo);
        }
    }
}