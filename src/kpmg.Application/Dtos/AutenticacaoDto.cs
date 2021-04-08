#region

using kpmg.Application.Bases;

#endregion

namespace kpmg.Application.Dtos
{
    public class AutenticacaoDto : EntityDto
    {
        public string Chave { get; set; }
        public string Senha { get; set; }
    }
}