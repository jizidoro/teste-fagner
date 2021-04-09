#region

using kpmg.Application.Dtos;

#endregion

namespace kpmg.Application.Validations.BaUsuValitation
{
    public class UsuarioSistemaIncluirValidation : UsuarioSistemaValidation<UsuarioSistemaIncluirDto>
    {
        public UsuarioSistemaIncluirValidation()
        {
            ValidarNome();
            ValidarEmail();
            ValidarSenha();
            ValidarMatricula();
        }
    }
}