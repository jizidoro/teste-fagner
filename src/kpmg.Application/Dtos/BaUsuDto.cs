#region

using System;
using kpmg.Application.Bases;

#endregion

namespace kpmg.Application.Dtos
{
    public class UsuarioSistemaDto : EntityDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } 
        public bool Situacao { get; set; }
        public string Matricula { get; set; }
    }
}