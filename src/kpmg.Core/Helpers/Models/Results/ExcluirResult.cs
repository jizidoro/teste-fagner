#region

using kpmg.Core.Helpers.Messages;
using kpmg.Domain.Bases;
using kpmg.Domain.Enums;

#endregion

namespace kpmg.Core.Helpers.Models.Results
{
    public class ExcluirResult<TEntity> : SingleResult<TEntity>
        where TEntity : Entity
    {
        public ExcluirResult()
        {
            Codigo = (int) EnumResultadoAcao.Sucesso;
            Sucesso = true;
            Mensagem = MensagensNegocio.ResourceManager.GetString("MSG03");
        }

        public ExcluirResult(bool sucesso, string mensagem)
        {
            Codigo = sucesso ? (int) EnumResultadoAcao.Sucesso : (int) EnumResultadoAcao.ErroNaoEncontrado;
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public ExcluirResult(string mensagem)
        {
            Codigo = (int) EnumResultadoAcao.ErroNaoEncontrado;
            Sucesso = false;
            Mensagem = mensagem;
        }
    }
}