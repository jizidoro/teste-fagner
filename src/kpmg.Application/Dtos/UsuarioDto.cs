#region

using kpmg.Application.Bases;

#endregion

namespace kpmg.Application.Dtos
{
    public class UsuarioDto : EntityDto
    {
        public string Token { get; set; }
    }
}