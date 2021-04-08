#region

using System.Threading.Tasks;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaUsuCore.Validation
{
    public class BaUsuValidarExcluir : EntityValidation<BaUsu>
    {
        private readonly IBaUsuRepository _repository;

        public BaUsuValidarExcluir(IBaUsuRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<BaUsu>> Execute(int id)
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