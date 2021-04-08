#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace kpmg.Domain.Models
{
    public class Autenticacao
    {
        [MaxLength(200)]
        [Required(ErrorMessage = "Chave is required")]
        public string Chave { get; set; }

        [MaxLength(200)]
        [MinLength(5)]
        [Required(ErrorMessage = "Senha is required")]
        public string Senha { get; set; }
    }
}