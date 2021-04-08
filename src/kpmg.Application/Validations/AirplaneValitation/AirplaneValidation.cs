#region

using kpmg.Application.Bases;
using kpmg.Application.Dtos;
using kpmg.Application.Messages;
using FluentValidation;

#endregion

namespace kpmg.Application.Validations.AirplaneValitation
{
    public class AirplaneValidation<TDto> : DtoValidation<TDto>
        where TDto : AirplaneDto
    {
        protected void ValidarId()
        {
            RuleFor(c => c.Id)
                .NotEqual(0);
        }

        protected void ValidarCodigo()
        {
            RuleFor(v => v.Codigo)
                .NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .MaximumLength(255).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("Codigo");
        }

        protected void ValidarModelo()
        {
            RuleFor(v => v.Modelo)
                .NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .MaximumLength(255).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
                .WithName("Modelo");
        }

        protected void ValidarQuantidadePassageiros()
        {
            RuleFor(v => v.QuantidadePassageiros)
                .NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
                .GreaterThanOrEqualTo(0).WithMessage(MensagensAplicacao.CAMPO_MAIOR_IGUAL_ZERO)
                .WithName("QuantidadePassageiros");
        }
    }
}