#region

using System.Threading.Tasks;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.AirplaneCore.Validation
{
    public class AirplaneValidarIncluir : EntityValidation<Airplane>
    {
        private readonly AirplaneValidarCodigoRepetido _airplaneValidarCodigoRepetido;
        private readonly IAirplaneRepository _repository;

        public AirplaneValidarIncluir(IAirplaneRepository repository,
            AirplaneValidarCodigoRepetido airplaneValidarCodigoRepetido)
            : base(repository)
        {
            _repository = repository;
            _airplaneValidarCodigoRepetido = airplaneValidarCodigoRepetido;
        }

        public async Task<ISingleResult<Airplane>> Execute(Airplane entity)
        {
            return await _airplaneValidarCodigoRepetido.Execute(entity);
        }
    }
}