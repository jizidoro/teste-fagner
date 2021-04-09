#region

using kpmg.Application.Dtos.AirplaneDtos;

#endregion

namespace kpmg.Application.Validations.AirplaneValitation
{
    public class AirplaneIncluirValidation : AirplaneValidation<AirplaneIncluirDto>
    {
        public AirplaneIncluirValidation()
        {
            ValidarCodigo();
            ValidarModelo();
            ValidarQuantidadePassageiro();
        }
    }
}