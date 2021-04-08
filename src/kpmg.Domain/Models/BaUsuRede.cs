#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_USU_REDE")]
    public class BaUsuRede : Entity
    {
        [Column("ID_USU", TypeName = "int", Order = 1)]
        [Required(ErrorMessage = "ID USU is required")]
        public int IdUsu { get; set; } // int, not null

        [Column("ID_REDE", TypeName = "int", Order = 2)]
        [Required(ErrorMessage = "ID REDE is required")]
        public int IdRede { get; set; } // int, not null
    }
}