#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_TIPO_CARGO")]
    public class BaTipoCargo : Entity
    {
        [Column("DS_TIPO_CARGO", TypeName = "varchar")]
        [MaxLength(50)]
        [Required(ErrorMessage = "DS TIPO CARGO is required")]
        public string DsTipoCargo { get; set; } // varchar(50), not null

        [Column("ID_USU", TypeName = "int")]
        [Required(ErrorMessage = "ID USU is required")]
        public int IdUsu { get; set; } // int, not null

        [Column("DT_CAD", TypeName = "datetime")]
        [Required(ErrorMessage = "DT CAD is required")]
        public DateTime DtCad { get; set; } // datetime, not null

        [Column("DT_ULT_ALT", TypeName = "datetime")]
        public DateTime? DtUltAlt { get; set; } // datetime, null

        public BaUsu BaUsu { get; set; }

        public List<BaCargo> BaCargos { get; set; } = new();
    }
}