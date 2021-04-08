#region

using System.Threading.Tasks;
using kpmg.Core.Utils;

#endregion

namespace kpmg.Core.SecurityCore
{
    public interface IGerarTokenLoginUsecase
    {
        Task<SecurityResult> Execute(string chave, string senha);
    }
}