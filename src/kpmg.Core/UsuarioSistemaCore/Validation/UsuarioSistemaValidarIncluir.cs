#region

using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.UsuarioSistemaCore.Validation
{
    public class UsuarioSistemaValidarIncluir : EntityValidation<UsuarioSistema>
    {
        private readonly IUsuarioSistemaRepository _repository;

        public UsuarioSistemaValidarIncluir(IUsuarioSistemaRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public ISingleResult<UsuarioSistema> Execute(UsuarioSistema entity)
        {
            return new SingleResult<UsuarioSistema>(entity);
        }
    }
}