#region

using System;
using System.Threading.Tasks;
using kpmg.Core.BaUsuCore.Validation;
using kpmg.Core.Helpers.Bases;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Messages;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaUsuCore.Usecase
{
    public class BaUsuExcluirUsecase : Service
    {
        private readonly BaUsuValidarExcluir _baUsuValidarExcluir;
        private readonly IBaUsuRepository _repository;

        public BaUsuExcluirUsecase(IBaUsuRepository repository, BaUsuValidarExcluir baUsuValidarExcluir,
            IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _baUsuValidarExcluir = baUsuValidarExcluir;
        }

        public async Task<ISingleResult<BaUsu>> Execute(int id)
        {
            try
            {
                var validacao = await _baUsuValidarExcluir.Execute(id);
                if (!validacao.Sucesso) return validacao;

                _repository.Remove(id);

                var sucesso = await Commit();
            }
            catch (Exception)
            {
                return new SingleResult<BaUsu>(MensagensNegocio.MSG07);
            }

            return new ExcluirResult<BaUsu>();
        }
    }
}