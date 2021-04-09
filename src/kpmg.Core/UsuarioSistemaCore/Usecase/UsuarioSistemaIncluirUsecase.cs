#region

using System;
using System.Threading.Tasks;
using kpmg.Core.UsuarioSistemaCore.Validation;
using kpmg.Core.Helpers.Bases;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Messages;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.UsuarioSistemaCore.Usecase
{
    public class UsuarioSistemaIncluirUsecase : Service
    {
        private readonly UsuarioSistemaValidarIncluir _usuarioSistemaValidarIncluir;
        private readonly IUsuarioSistemaRepository _repository;

        public UsuarioSistemaIncluirUsecase(IUsuarioSistemaRepository repository, UsuarioSistemaValidarIncluir usuarioSistemaValidarIncluir,
            IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _usuarioSistemaValidarIncluir = usuarioSistemaValidarIncluir;
        }

        public async Task<ISingleResult<UsuarioSistema>> Execute(UsuarioSistema entity)
        {
            try
            {
                var isValid = ValidarEntidade(entity);
                if (!isValid.Sucesso)
                {
                    return isValid;
                }

                var validacao = _usuarioSistemaValidarIncluir.Execute(entity);
                if (!validacao.Sucesso) return validacao;
                await _repository.Add(entity);

                var sucesso = await Commit();
            }
            catch (Exception)
            {
                return new SingleResult<UsuarioSistema>(MensagensNegocio.MSG07);
            }

            return new IncluirResult<UsuarioSistema>(entity);
        }
    }
}