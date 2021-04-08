#region

using System;
using System.Threading.Tasks;
using kpmg.Core.AirplaneCore.Validation;
using kpmg.Core.Helpers.Bases;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Messages;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.AirplaneCore.Usecase
{
    public class AirplaneExcluirUsecase : Service
    {
        private readonly AirplaneValidarExcluir _airplaneValidarExcluir;
        private readonly IAirplaneRepository _repository;

        public AirplaneExcluirUsecase(IAirplaneRepository repository, AirplaneValidarExcluir airplaneValidarExcluir,
            IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _airplaneValidarExcluir = airplaneValidarExcluir;
        }

        public async Task<ISingleResult<Airplane>> Execute(int id)
        {
            try
            {
                var validacao = await _airplaneValidarExcluir.Execute(id);
                if (!validacao.Sucesso) return validacao;

                _repository.Remove(id);

                var sucesso = await Commit();
            }
            catch (Exception)
            {
                return new SingleResult<Airplane>(MensagensNegocio.MSG07);
            }

            return new ExcluirResult<Airplane>();
        }
    }
}