#region

using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaUsuCore.Validation
{
    public class BaUsuValidarEsquecerSenha : EntityValidation<BaUsu>
    {
        private readonly BaUsuValidarEditar _baUsuValidarEditar;
        private readonly IBaUsuRepository _repository;

        public BaUsuValidarEsquecerSenha(IBaUsuRepository repository, BaUsuValidarEditar baUsuValidarEditar)
            : base(repository)
        {
            _repository = repository;
            _baUsuValidarEditar = baUsuValidarEditar;
        }

        public ISingleResult<BaUsu> Execute(BaUsu entity)
        {
            var registroExiste = _baUsuValidarEditar.Execute(entity).Result;

            if (!registroExiste.Sucesso)
            {
                return registroExiste;
            }

            if (!string.IsNullOrEmpty(registroExiste.Data.Cpf) && registroExiste.Data.Cpf.Length >= 6)
            {
                return registroExiste;
            }

            return new SingleResult<BaUsu>(1004, "Usuario com cpf invalido");
        }
    }
}