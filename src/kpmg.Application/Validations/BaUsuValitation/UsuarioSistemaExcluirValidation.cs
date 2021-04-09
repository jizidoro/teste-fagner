#region

using kpmg.Application.Dtos.UsuarioSistemaDtos;

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