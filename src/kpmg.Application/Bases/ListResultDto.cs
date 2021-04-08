#region

using System.Collections.Generic;
using kpmg.Application.Utils;
using kpmg.Core.Helpers.Messages;
using kpmg.Domain.Enums;

#endregion

namespace kpmg.Application.Bases
{
    public class ListResultDto<T> : ResultDto, IListResultDto<T>
        where T : Dto
    {
        public ListResultDto()
        {
        }

        public ListResultDto(IList<T> data)
        {
            Data = data;
            Codigo = data == null ? (int) EnumResultadoAcao.ErroNaoEncontrado : (int) EnumResultadoAcao.Sucesso;
            Sucesso = data != null;
            Mensagem = data == null ? MensagensNegocio.ResourceManager.GetString("MSG04") : string.Empty;
        }

        public ListResultDto(int codigo, string menssagem)
        {
            Codigo = codigo;
            Sucesso = false;
            Mensagem = menssagem;
        }

        public ListResultDto(string menssagem)
        {
            Codigo = (int) EnumResultadoAcao.ErroValidacaoNegocio;
            Sucesso = false;
            Mensagem = menssagem;
        }

        public IList<T> Data { get; set; }
    }
}