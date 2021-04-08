#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_LOGRADOURO")]
    public class BaLogradouro : Entity
    {
        [Column("LOGRADOURO", TypeName = "varchar")]
        [MaxLength(200)]
        [Required(ErrorMessage = "LOGRADOURO is required")]
        public string Logradouro { get; set; } // varchar(200), not null

        [Column("BAIRRO", TypeName = "varchar")]
        [MaxLength(100)]
        [Required(ErrorMessage = "BAIRRO is required")]
        public string Bairro { get; set; } // varchar(100), not null

        [Column("ID_CIDADE", TypeName = "int")]
        [Required(ErrorMessage = "ID CIDADE is required")]
        public int IdCidade { get; set; } // int, not null

        [Column("CEP", TypeName = "varchar")]
        [MaxLength(8)]
        [Required(ErrorMessage = "CEP is required")]
        public string Cep { get; set; } // varchar(8), not null

        [Column("ID_USU", TypeName = "int")]
        [Required(ErrorMessage = "ID USU is required")]
        public int IdUsu { get; set; } // int, not null


        [Column("DT_CAD", TypeName = "datetime")]
        [Required(ErrorMessage = "DT CAD is required")]
        public DateTime DtCad { get; set; } // datetime, not null

        [Column("DT_ULT_ALT", TypeName = "datetime")]
        public DateTime? DtUltAlt { get; set; } // datetime, null

        public virtual BaUsu BaUsu { get; set; }
        public virtual IEnumerable<BaUsu> BaUsus { get; set; }
        public virtual IEnumerable<BaFilial> BaFiliais { get; set; }
    }
}