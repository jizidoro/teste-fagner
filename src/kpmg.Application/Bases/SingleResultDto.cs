#region

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using kpmg.Application.Utils;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Messages;
using kpmg.Core.Utils;
using kpmg.Domain.Bases;
using kpmg.Domain.Enums;

#endregion

namespace kpmg.Application.Bases
{
    public class SingleResultDto<TDto> : ResultDto, ISingleResultDto<TDto>
        where TDto : Dto
    {
        public SingleResultDto(TDto data)
        {
            Codigo = data == null ? (int) EnumResultadoAcao.ErroNaoEncontrado : (int) EnumResultadoAcao.Sucesso;
            Sucesso = data != null;
            Mensagem = data == null ? MensagensNegocio.ResourceManager.GetString("MSG04") : string.Empty;
            Data = data;
        }

        public SingleResultDto()
        {
            Codigo = (int) EnumResultadoAcao.ErroNaoEncontrado;
            Sucesso = false;
            Mensagem = MensagensNegocio.ResourceManager.GetString("MSG04");
            Data = null;
        }

        public SingleResultDto(SecurityResult erroSecurity)
        {
            Codigo = erroSecurity.ErrorCode;
            Sucesso = false;
            Mensagem = erroSecurity.ErrorMessage;
            Data = null;
        }


        public SingleResultDto(Exception ex)
        {
            Codigo = (int) EnumResultadoAcao.ErroServidor;
            Sucesso = false;
            Mensagem = ex.Message;
        }

        public SingleResultDto(IEnumerable<string> listaErros)
        {
            Codigo = (int) EnumResultadoAcao.ErroValidacaoNegocio;
            Sucesso = false;
            Mensagens = listaErros.ToList();
        }

        public SingleResultDto(IResult result)
        {
            Codigo = result.Codigo;
            Sucesso = result.Sucesso;
            Mensagem = result.Mensagem;
        }

        public SingleResultDto(int codigo, bool sucesso, string mensagem)
        {
            Codigo = codigo;
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public TDto Data { get; private set; }

        public void SetData<TEntity>(ISingleResult<TEntity> result, IMapper mapper)
            where TEntity : Entity
        {
            Data = mapper.Map<TDto>(result.Data);
        }
    }
}