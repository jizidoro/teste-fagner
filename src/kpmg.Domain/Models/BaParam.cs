#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_PARAM")]
    public class BaParam
    {
        [Key]
        [Column("CHAVE", TypeName = "varchar")]
        [MaxLength(256)]
        [Required(ErrorMessage = "CHAVE is required")]
        public string Chave { get; set; } // varchar(256), not null

        [Column("VALOR", TypeName = "varchar")]
        [MaxLength]
        [Required(ErrorMessage = "VALOR is required")]
        public string Valor { get; set; } // varchar(max), not null
    }
}