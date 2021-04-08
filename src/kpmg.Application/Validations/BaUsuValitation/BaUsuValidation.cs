#region

using kpmg.Application.Bases;
using kpmg.Application.Dtos;
using kpmg.Application.Messages;
using FluentValidation;

#endregion

namespace kpmg.Application.Validations.BaUsuValitation
{
    public class BaUsuValidation<TDto> : DtoValidation<TDto>
        where TDto : BaUsuDto
    {
        protected void ValidarId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected void ValidarNomeUsu()
        {
            RuleFor(v => v.NomeUsu)
                .NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .MaximumLength(250).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("NomeUsu");
        }

        protected void ValidarCpf()
        {
            RuleFor(v => v.Cpf)
                .NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .MaximumLength(11).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("Cpf");
        }

        protected void ValidarTelefone1()
        {
            RuleFor(v => v.Telefone1)
                .MinimumLength(9).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .MaximumLength(15).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("Telefone1");
        }

        protected void ValidarTelefone2()
        {
            RuleFor(v => v.Telefone1)
                .MinimumLength(9).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .MaximumLength(15).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("Telefone2");
        }

        protected void ValidarTelefone3()
        {
            RuleFor(v => v.Telefone1)
                .MinimumLength(9).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .MaximumLength(15).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("Telefone3");
        }

        protected void ValidarIdLogradouro()
        {
            RuleFor(v => v.IdLogradouro)
                .NotEqual(0).WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .NotNull().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .WithName("IdLogradouro");
        }

        protected void ValidarNrLogradouro()
        {
            RuleFor(v => v.NrLogradouro)
                .NotEqual(0).WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .NotNull().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .WithName("NrLogradouro");
        }

        protected void ValidarCplLogradouro()
        {
            RuleFor(v => v.CplLogradouro)
                .MaximumLength(100).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("CplLogradouro");
        }

        protected void ValidarEmail()
        {
            RuleFor(v => v.Email)
                .MaximumLength(250).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("Email");
        }

        protected void ValidarSenha()
        {
            RuleFor(v => v.Senha)
                .NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .MinimumLength(4).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .MaximumLength(40).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("Senha");
        }

        protected void ValidarStsUsu()
        {
            RuleFor(v => v.StsUsu)
                .NotEqual(0).WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .NotNull().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .WithName("StsUsu");
        }


        protected void ValidarCodCargo()
        {
            RuleFor(v => v.CodCargo)
                .NotEqual(0).WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .NotNull().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .WithName("CodCargo");
        }


        protected void ValidarDtAdmissao()
        {
            RuleFor(v => v.DtAdmissao)
                .NotNull().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .WithName("DtAdmissao");
        }

        protected void ValidarMatricula()
        {
            RuleFor(v => v.Matricula)
                .NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .MaximumLength(30).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("Matricula");
        }

        protected void ValidarNomeRede()
        {
            RuleFor(v => v.NomeRede)
                .MaximumLength(150).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("NomeRede");
        }

        protected void ValidarSituacaoFolha()
        {
            RuleFor(v => v.SituacaoFolha)
                .MaximumLength(200).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("SituacaoFolha");
        }

        protected void ValidarIdUsuCad()
        {
            RuleFor(v => v.IdUsuCad)
                .NotEqual(0).WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .NotNull().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .WithName("IdUsuCad");
        }

        protected void ValidarDtCad()
        {
            RuleFor(v => v.DtCad)
                .NotNull().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .WithName("DtCad");
        }
    }
}