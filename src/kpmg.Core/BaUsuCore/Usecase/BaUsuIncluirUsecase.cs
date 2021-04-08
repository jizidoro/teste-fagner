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
    public class BaUsuIncluirUsecase : Service
    {
        private readonly BaUsuValidarIncluir _baUsuValidarIncluir;
        private readonly IBaUsuRepository _repository;

        public BaUsuIncluirUsecase(IBaUsuRepository repository, BaUsuValidarIncluir baUsuValidarIncluir,
            IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _baUsuValidarIncluir = baUsuValidarIncluir;
        }

        public async Task<ISingleResult<BaUsu>> Execute(BaUsu entity)
        {
            try
            {
                var isValid = ValidarEntidade(entity);
                if (!isValid.Sucesso)
                {
                    return isValid;
                }

                var validacao = await _baUsuValidarIncluir.Execute(entity);
                if (!validacao.Sucesso) return validacao;
                await _repository.Add(entity);

                var sucesso = await Commit();
            }
            catch (Exception)
            {
                return new SingleResult<BaUsu>(MensagensNegocio.MSG07);
            }

            return new IncluirResult<BaUsu>(entity);
        }
    }
}