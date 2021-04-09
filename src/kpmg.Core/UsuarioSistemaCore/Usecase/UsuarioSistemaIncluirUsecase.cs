#region

using System;
using System.Threading.Tasks;
using kpmg.Core.Helpers.Bases;
using kpmg.Core.Helpers.Extensions;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Messages;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Core.UsuarioSistemaCore.Validation;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.UsuarioSistemaCore.Usecase
{
    public class UsuarioSistemaIncluirUsecase : Service
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsuarioSistemaRepository _repository;
        private readonly UsuarioSistemaValidarIncluir _usuarioSistemaValidarIncluir;

        public UsuarioSistemaIncluirUsecase(IUsuarioSistemaRepository repository,
            UsuarioSistemaValidarIncluir usuarioSistemaValidarIncluir,
            IPasswordHasher passwordHasher, IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _usuarioSistemaValidarIncluir = usuarioSistemaValidarIncluir;
            _passwordHasher = passwordHasher;
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

                entity.Senha = _passwordHasher.Hash(entity.Senha);
                entity.DataRegistro = HorariosFusoExtensions.ObterHorarioBrasilia();

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