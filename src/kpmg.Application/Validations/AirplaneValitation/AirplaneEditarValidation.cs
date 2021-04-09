#region

using kpmg.Application.Dtos.AirplaneDtos;

#endregion

namespace kpmg.Application.Validations.AirplaneValitation
{
    public class AirplaneEditarValidation : AirplaneValidation<AirplaneEditarDto>
    {
        public AirplaneEditarValidation()
        {
            ValidarId();
            ValidarCodigo();
            ValidarModelo();
            ValidarQuantidadePassageiro();
        }
    }
}