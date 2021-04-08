#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_USU_PERMISSAO")]
    public class BaUsuPermissao
    {
        [Column("ID_USU", TypeName = "int", Order = 1)]
        [Required(ErrorMessage = "ID USU is required")]
        public int IdUsu { get; set; } // int, not null

        [Column("ID_MODULO", TypeName = "int", Order = 2)]
        [Required(ErrorMessage = "ID MODULO is required")]
        public int IdModulo { get; set; } // int, not null

        [Column("ID_TELA", TypeName = "int", Order = 3)]
        [Required(ErrorMessage = "ID TELA is required")]
        public int IdTela { get; set; } // int, not null

        [Column("ID_PERMISSAO", TypeName = "int", Order = 4)]
        [Required(ErrorMessage = "ID PERMISSAO is required")]
        public int IdPermissao { get; set; } // int, not null


        public BaUsu BaUsu { get; set; }

        public BaPermissao BaPermissao { get; set; }

        public BaTela BaTela { get; set; }

        public BaModulo BaModulo { get; set; }
    }
}