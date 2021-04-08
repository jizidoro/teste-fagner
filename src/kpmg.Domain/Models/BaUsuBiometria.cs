#region

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_USU_BIOMETRIA")]
    public class BaUsuBiometria : Entity
    {
        [Column("ID_USU", TypeName = "int")]
        [Required(ErrorMessage = "ID USU is required")]
        public int IdUsu { get; set; } // int, not null

        [Column("ID_DEDO", TypeName = "int")]
        [Required(ErrorMessage = "ID DEDO is required")]
        public int IdDedo { get; set; } // int, not null

        [Column("FINGERPRINT", TypeName = "varbinary")]
        [MaxLength]
        [Required(ErrorMessage = "FINGERPRINT is required")]
        public byte[] Fingerprint { get; set; } // varbinary(max), not null

        [Column("DT_CAD", TypeName = "datetime")]
        [Required(ErrorMessage = "DT CAD is required")]
        public DateTime DtCad { get; set; } // datetime, not null

        [Column("TEMPLATE", TypeName = "varchar")]
        [MaxLength]
        [Required(ErrorMessage = "TEMPLATE is required")]
        public string Template { get; set; } // varchar(max), not null
    }
}