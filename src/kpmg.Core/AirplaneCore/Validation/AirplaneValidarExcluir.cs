#region

using System.Threading.Tasks;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.AirplaneCore.Validation
{
    public class AirplaneValidarExcluir : EntityValidation<Airplane>
    {
        private readonly IAirplaneRepository _repository;

        public AirplaneValidarExcluir(IAirplaneRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<Airplane>> Execute(int id)
        {
            var registroExiste = await RegistroExiste(id);
            if (!registroExiste.Sucesso)
            {
                return registroExiste;
            }

            return registroExiste;
        }
    }
}