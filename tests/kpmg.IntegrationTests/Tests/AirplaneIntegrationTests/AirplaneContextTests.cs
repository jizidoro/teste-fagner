using System.Threading.Tasks;
using kpmg.Domain.Models;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace kpmg.IntegrationTests.Tests.AirplaneIntegrationTests
{
    public class AirplaneContextTests
    {

        [Fact]
        public async Task Airplane_Context()
        {
            var options = new DbContextOptionsBuilder<KpmgContext>()
                .UseInMemoryDatabase("test_database_return_Get_ReturnsAirplane")
                .Options;

            Airplane airplane = null;

            await using var context = new KpmgContext(options);
            await context.Database.EnsureCreatedAsync();
            Utilities.InitializeDbForTests(context);
            var repository = new AirplaneRepository(context);
            airplane = await repository.GetById(1);
            Assert.NotNull(airplane);
        }
    }
}