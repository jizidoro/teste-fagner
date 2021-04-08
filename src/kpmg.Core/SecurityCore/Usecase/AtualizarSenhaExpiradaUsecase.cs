#region

using System;
using System.Threading.Tasks;
using kpmg.Core.BaUsuCore;
using kpmg.Core.BaUsuCore.Validation;
using kpmg.Core.Helpers.Bases;
using kpmg.Core.Helpers.Extensions;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.SecurityCore.Usecase
{
    public class AtualizarSenhaExpiradaUsecase : Service
    {
        private readonly BaUsuValidarEditar _baUsuValidarEditar;
        private readonly IBaUsuRepository _repository;

        public AtualizarSenhaExpiradaUsecase(IBaUsuRepository repository, BaUsuValidarEditar baUsuValidarEditar,
            IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
            _baUsuValidarEditar = baUsuValidarEditar;
        }

        public async Task<ISingleResult<BaUsu>> Execute(BaUsu entity)
        {
            try
            {
                var result = await _baUsuValidarEditar.Execute(entity);
                if (!result.Sucesso) return result;

                var obj = result.Data;

                HydrateValues(obj, entity);

                _repository.Update(obj);

                var sucesso = await Commit();
            }
            catch (Exception ex)
            {
                return new SingleResult<BaUsu>(ex);
            }

            return new EditarResult<BaUsu>();
        }

        private void HydrateValues(BaUsu target, BaUsu source)
        {
            target.Senha = ItecIntegrationExtensions.Cifrar(source.Senha);
            target.UltAltSenha = HorariosFusoExtensions.ObterHorarioBrasilia();
            target.DtUltAlt = HorariosFusoExtensions.ObterHorarioBrasilia();
        }
    }
}