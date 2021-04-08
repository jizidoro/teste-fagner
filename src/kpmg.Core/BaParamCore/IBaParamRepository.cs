#region

using System.Threading.Tasks;

#endregion

namespace kpmg.Core.BaParamCore
{
    public interface IBaParamRepository
    {
        Task<string> ObterValorPorChave(string chave);

        Task<string> ObterValorQtdeDiasTrocarSenhaSistema();
    }
}