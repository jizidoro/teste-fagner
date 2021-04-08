#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_USU_GRUPO_ECONOMICO")]
    public class BaUsuGrupoEconomico : Entity
    {
        [Column("ID_USU", TypeName = "int", Order = 1)]
        [Required(ErrorMessage = "ID USU is required")]
        public int IdUsu { get; set; } // int, not null

        [Column("ID_GRUPO_ECONOMICO", TypeName = "int", Order = 2)]
        [Required(ErrorMessage = "ID GRUPO ECONOMICO is required")]
        public int IdGrupoEconomico { get; set; } // int, not null
    }
}