#region

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_CARGO")]
    public class BaCargo : Entity
    {
        [Column("NOME_CARGO", TypeName = "varchar")]
        [MaxLength(200)]
        [Required(ErrorMessage = "NOME CARGO is required")]
        public string NomeCargo { get; set; } // varchar(200), not null

        [Column("TIPO_CARGO", TypeName = "int")]
        [Required(ErrorMessage = "TIPO CARGO is required")]
        public int TipoCargo { get; set; } // int, not null

        [Column("ID_USU", TypeName = "int")]
        [Required(ErrorMessage = "ID USU is required")]
        public int IdUsu { get; set; } // int, not null

        [Column("DT_CAD", TypeName = "datetime")]
        [Required(ErrorMessage = "DT CAD is required")]
        public DateTime DtCad { get; set; } // datetime, not null

        [Column("DT_ULT_ALT", TypeName = "datetime")]
        public DateTime? DtUltAlt { get; set; } // datetime, null

        [Column("EXIGE_SENHA_ORC", TypeName = "bit")]
        [Required(ErrorMessage = "EXIGE SENHA ORC is required")]
        public bool ExigeSenhaOrc { get; set; } // bit, not null

        public BaTipoCargo BaTipoCargo { get; set; }

        public virtual BaUsu BaUsu { get; set; }
    }
}