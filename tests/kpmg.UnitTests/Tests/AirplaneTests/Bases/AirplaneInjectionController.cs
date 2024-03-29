﻿#region

using kpmg.Infrastructure.DataAccess;
using kpmg.UnitTests.Helpers;
using kpmg.WebApi.UseCases.V1.AirplaneApi;

#endregion

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