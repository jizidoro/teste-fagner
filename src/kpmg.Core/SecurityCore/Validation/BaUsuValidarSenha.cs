#region

using System.Threading.Tasks;
using kpmg.Core.BaUsuCore;
using kpmg.Core.BaUsuCore.Validation;
using kpmg.Core.Helpers.Extensions;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.SecurityCore.Validation
{
    public class BaUsuValidarSenha : EntityValidation<BaUsu>
    {
        private readonly IBaUsuRepository _baUsuRepository;
        private readonly BaUsuValidarSenhaExpirada _baUsuValidarSenhaExpirada;

        public BaUsuValidarSenha(IBaUsuRepository baUsuRepository, BaUsuValidarSenhaExpirada baUsuValidarSenhaExpirada)
            : base(baUsuRepository)
        {
            _baUsuRepository = baUsuRepository;
            _baUsuValidarSenhaExpirada = baUsuValidarSenhaExpirada;
        }

        public async Task<ISingleResult<BaUsu>> Execute(string chave, string senha)
        {
            var success = int.TryParse(chave, out var number);

            if (success)
            {
                var usuSelecionado = _baUsuRepository.GetById(number).Result;
                var chaveValida = usuSelecionado != null;

                if (chaveValida)
                {
                    var tempCalc = ItecIntegrationExtensions.Cifrar(senha);
                    var senhaValida = !string.IsNullOrEmpty(senha) && usuSelecionado.Senha.Equals(tempCalc);

                    if (!senhaValida)
                    {
                        return new SingleResult<BaUsu>(1001, "Usuário ou senha informados não são válidos");
                    }

                    var isSenhaExpirada = await _baUsuValidarSenhaExpirada.Execute(usuSelecionado);

                    if (isSenhaExpirada)
                    {
                        return new SingleResult<BaUsu>(1002, "Senha expirada");
                    }

                    return new SingleResult<BaUsu>(usuSelecionado);
                }


                return new SingleResult<BaUsu>(1001, "Usuário ou senha informados não são válidos");
            }

            return new SingleResult<BaUsu>(1001, "Usuário ou senha informados não são válidos");
        }
    }
}