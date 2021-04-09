#region

using System;
using System.Threading.Tasks;
using kpmg.Core.Helpers.Bases;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Messages;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Core.UsuarioSistemaCore.Validation;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.UsuarioSistemaCore.Usecase
{
    public class UsuarioSistemaExcluirUsecase : Service
    {
        private readonly IUsuarioSistemaRepository _repository;
        private readonly UsuarioSistemaValidarExcluir _usuarioSistemaValidarExcluir;

        public UsuarioSistemaExcluirUsecase(IUsuarioSistemaRepository repository,
            UsuarioSistemaValidarExcluir usuarioSistemaValidarExcluir,
            IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _usuarioSistemaValidarExcluir = usuarioSistemaValidarExcluir;
        }

        public async Task<ISingleResult<UsuarioSistema>> Execute(int id)
        {
            try
            {
                var validacao = await _usuarioSistemaValidarExcluir.Execute(id);
                if (!validacao.Sucesso) return validacao;

                _repository.Remove(id);

                var sucesso = await Commit();
            }
            catch (Exception)
            {
                return new SingleResult<UsuarioSistema>(MensagensNegocio.MSG07);
            }

            return new ExcluirResult<UsuarioSistema>();
        }
    }
}