#region

using System.Threading.Tasks;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.UsuarioSistemaCore.Validation
{
    public class UsuarioSistemaValidarExcluir : EntityValidation<UsuarioSistema>
    {
        private readonly IUsuarioSistemaRepository _repository;

        public UsuarioSistemaValidarExcluir(IUsuarioSistemaRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<UsuarioSistema>> Execute(int id)
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