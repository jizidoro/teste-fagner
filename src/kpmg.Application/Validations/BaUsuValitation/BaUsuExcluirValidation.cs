#region

using kpmg.Application.Dtos;

#endregion

namespace kpmg.Application.Validations.BaUsuValitation
{
    public class BaUsuExcluirValidation : BaUsuValidation<BaUsuDto>
    {
        public BaUsuExcluirValidation()
        {
            ValidarId();
        }
    }
}