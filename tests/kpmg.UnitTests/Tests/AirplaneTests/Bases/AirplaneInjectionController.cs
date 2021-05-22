using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kpmg.Infrastructure.DataAccess;
using kpmg.UnitTests.Helpers;
using kpmg.WebApi.UseCases.V1.AirplaneApi;

namespace kpmg.UnitTests.Tests.AirplaneTests.Bases
{
    public class AirplaneInjectionController
    {
        private readonly AirplaneInjectionAppService _airplaneInjectionAppService = new();

        public AirplaneController ObterAirplaneController(KpmgContext context)
        {
            var mapper = MapperHelper.ConfigMapper();

            var airplaneAppService = _airplaneInjectionAppService.ObterAirplaneAppService(context, mapper);

            return new AirplaneController(airplaneAppService, mapper);
        }
    }
}
