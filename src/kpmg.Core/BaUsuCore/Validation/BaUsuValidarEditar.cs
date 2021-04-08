#region

using System.Threading.Tasks;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaUsuCore.Validation
{
    public class BaUsuValidarEditar : EntityValidation<BaUsu>
    {
        private readonly IBaUsuRepository _repository;

        public BaUsuValidarEditar(IBaUsuRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<BaUsu>> Execute(BaUsu entity)
        {
            var registroExiste = await RegistroExiste(entity.Id);
            if (!registroExiste.Sucesso)
            {
                return registroExiste;
            }

            return registroExiste;
        }
    }
}