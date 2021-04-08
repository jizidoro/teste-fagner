#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_USU_FILIAL")]
    public class BaUsuFilial
    {
        [Column("ID_USU", TypeName = "int", Order = 1)]
        [Required(ErrorMessage = "ID USU is required")]
        public int IdUsu { get; set; } // int, not null

        [Column("ID_FILIAL", TypeName = "int", Order = 2)]
        [Required(ErrorMessage = "ID FILIAL is required")]
        public int IdFilial { get; set; } // int, not null


        public BaUsu BaUsu { get; set; }
        public BaFilial BaFilial { get; set; }
    }
}