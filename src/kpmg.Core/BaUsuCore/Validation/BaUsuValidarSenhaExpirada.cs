#region

using System;
using System.Threading.Tasks;
using kpmg.Core.BaParamCore;
using kpmg.Core.Helpers.Extensions;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaUsuCore.Validation
{
    public class BaUsuValidarSenhaExpirada : EntityValidation<BaUsu>
    {
        private readonly IBaParamRepository _baParamRepository;
        private readonly IBaUsuRepository _baUsuRepository;

        public BaUsuValidarSenhaExpirada(IBaUsuRepository baUsuRepository, IBaParamRepository baParamRepository)
            : base(baUsuRepository)
        {
            _baUsuRepository = baUsuRepository;
            _baParamRepository = baParamRepository;
        }

        public async Task<bool> Execute(BaUsu entity)
        {
            var result = await _baParamRepository.ObterValorQtdeDiasTrocarSenhaSistema();

            var success = int.TryParse(result, out var number);
            if (success && number > 0)
            {
                var qtdeDiasTrocarSenhaSistema = number;

                if (entity.UltAltSenha != null)
                {
                    var dataExpirar = entity.UltAltSenha.Value.AddDays(qtdeDiasTrocarSenhaSistema);
                    var isSenhaExpirada = DateTime.Compare(dataExpirar, HorariosFusoExtensions.ObterHorarioBrasilia());
                    if (isSenhaExpirada < 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            else
            {
                return false;
            }

            return false;
        }
    }
}