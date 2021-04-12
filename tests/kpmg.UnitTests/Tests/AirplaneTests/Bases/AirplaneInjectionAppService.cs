#region

#endregion

using AutoMapper;
using kpmg.Application.Services;
using kpmg.Core.AirplaneCore.Usecase;
using kpmg.Core.AirplaneCore.Validation;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;

namespace kpmg.UnitTests.Tests.AirplaneTests.Bases
{
    public sealed class AirplaneInjectionAppService
    {
        public AirplaneAppService ObterAirplaneAppService(KpmgContext context, IMapper mapper)
        {
            var uow = new UnitOfWork(context);
            var airplaneRepository = new AirplaneRepository(context);

            var airplaneValidarCodigoRepetido = new AirplaneValidarCodigoRepetido(airplaneRepository);


            var airplaneValidarEditar =
                new AirplaneValidarEditar(airplaneRepository, airplaneValidarCodigoRepetido);
            var airplaneValidarExcluir = new AirplaneValidarExcluir(airplaneRepository);
            var airplaneValidarIncluir =
                new AirplaneValidarIncluir(airplaneRepository, airplaneValidarCodigoRepetido);
            var airplaneIncluirUsecase = new AirplaneIncluirUsecase(airplaneRepository, airplaneValidarIncluir, uow);
            var airplaneExcluirUsecase = new AirplaneExcluirUsecase(airplaneRepository, airplaneValidarExcluir, uow);
            var airplaneEditarUsecase = new AirplaneEditarUsecase(airplaneRepository, airplaneValidarEditar, uow);
            
            return new AirplaneAppService(airplaneRepository, airplaneEditarUsecase, airplaneIncluirUsecase,
                airplaneExcluirUsecase, mapper);
        }
    }
}