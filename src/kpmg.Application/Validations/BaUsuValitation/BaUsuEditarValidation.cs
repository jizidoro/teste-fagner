#region

using kpmg.Application.Dtos;

#endregion

namespace kpmg.Application.Validations.BaUsuValitation
{
    public class UsuarioSistemaEditarValidation : UsuarioSistemaValidation<UsuarioSistemaEditarDto>
    {
        public UsuarioSistemaEditarValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarEmail();
            ValidarSenha();
            ValidarMatricula();
        }
    }
}