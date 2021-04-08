#region

using kpmg.Application.Dtos;

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
            ValidarQuantidadePassageiros();
        }
    }
}