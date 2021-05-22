#region

using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos.AirplaneDtos;
using kpmg.Infrastructure.DataAccess;
using kpmg.UnitTests.Helpers;
using kpmg.UnitTests.Tests.AirplaneTests.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

#endregion

namespace kpmg.IntegrationTests.Tests.AirplaneIntegrationTests
{
    public class AirplaneControllerListarTests
    {
        private readonly AirplaneInjectionController _airplaneInjectionController = new();

        [Fact]
        public async Task AirplaneController_Listar()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_AirplaneController_Listar")
                .Options;


            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);

            var airplaneController = _airplaneInjectionController.ObterAirplaneController(context);
            var result = await airplaneController.Listar(null);

            if (result is OkObjectResult okResult)
            {
                var actualResultValue = okResult.Value as PageResultDto<AirplaneDto>;
                Assert.NotNull(actualResultValue);
                Assert.Equal(200, actualResultValue.Codigo);
                Assert.NotNull(actualResultValue.Data);
                Assert.Equal(3, actualResultValue.Data.Count);
            }
        }
    }
}