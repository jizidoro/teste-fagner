#region

using kpmg.Application.Dtos;

#endregion

namespace kpmg.Application.Validations.BaUsuValitation
{
    public class UsuarioSistemaExcluirValidation : UsuarioSistemaValidation<UsuarioSistemaDto>
    {
        public UsuarioSistemaExcluirValidation()
        {
            ValidarId();
        }
    }
}