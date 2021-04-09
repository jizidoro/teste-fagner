#region

using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.UsuarioSistemaCore.Validation
{
    public class UsuarioSistemaValidarEsquecerSenha : EntityValidation<UsuarioSistema>
    {
        private readonly UsuarioSistemaValidarEditar _usuarioSistemaValidarEditar;
        private readonly IUsuarioSistemaRepository _repository;

        public UsuarioSistemaValidarEsquecerSenha(IUsuarioSistemaRepository repository,
            UsuarioSistemaValidarEditar usuarioSistemaValidarEditar)
            : base(repository)
        {
            _repository = repository;
            _usuarioSistemaValidarEditar = usuarioSistemaValidarEditar;
        }

        public ISingleResult<UsuarioSistema> Execute(UsuarioSistema entity)
        {
            var registroExiste = _usuarioSistemaValidarEditar.Execute(entity).Result;

            if (!registroExiste.Sucesso)
            {
                return new SingleResult<UsuarioSistema>(1001, "Usuario não existe");
            }


            return registroExiste;
        }
    }
}