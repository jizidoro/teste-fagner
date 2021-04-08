#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;
using kpmg.Domain.CustomDataAnnotations;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_USU")]
    public class BaUsu : Entity
    {
        [Column("NOME_USU", TypeName = "varchar")]
        [MaxLength(250)]
        [Required(ErrorMessage = "NOME USU is required")]
        public string NomeUsu { get; set; } // varchar(250), not null

        [Column("CPF", TypeName = "varchar")]
        [MaxLength(11)]
        [Required(ErrorMessage = "CPF is required")]
        public string Cpf { get; set; } // varchar(11), not null

        [Column("DT_NASC", TypeName = "date")] public DateTime? DtNasc { get; set; } // date, null

        [Column("TELEFONE1", TypeName = "varchar")]
        [MaxLength(15)]
        public string Telefone1 { get; set; } // varchar(15), null

        [Column("TELEFONE2", TypeName = "varchar")]
        [MaxLength(15)]
        public string Telefone2 { get; set; } // varchar(15), null

        [Column("TELEFONE3", TypeName = "varchar")]
        [MaxLength(15)]
        public string Telefone3 { get; set; } // varchar(15), null

        [Column("ID_LOGRADOURO", TypeName = "int")]
        public int? IdLogradouro { get; set; } // int, null

        [Column("NR_LOGRADOURO", TypeName = "int")]
        [Required(ErrorMessage = "NR LOGRADOURO is required")]
        public int? NrLogradouro { get; set; } // int, not null

        [Column("CPL_LOGRADOURO", TypeName = "varchar")]
        [MaxLength(100)]
        public string CplLogradouro { get; set; } // varchar(100), null

        [Column("EMAIL", TypeName = "varchar")]
        [MaxLength(250)]
        public string Email { get; set; } // varchar(250), null

        [Column("SENHA", TypeName = "varchar")]
        [MaxLength(40)]
        [Required(ErrorMessage = "SENHA is required")]
        public string Senha { get; set; } // varchar(40), not null

        [Column("ULT_ALT_SENHA", TypeName = "datetime")]
        public DateTime? UltAltSenha { get; set; } // datetime, null

        [Column("STS_USU", TypeName = "int")]
        [Required(ErrorMessage = "STS USU is required")]
        public int? StsUsu { get; set; } // int, not null

        [Column("COD_CARGO", TypeName = "int")]
        [Required(ErrorMessage = "COD CARGO is required")]
        [IdNotZeroValidation]
        public int CodCargo { get; set; } // int, not null

        [Column("DT_ADMISSAO", TypeName = "date")]
        [Required(ErrorMessage = "DT ADMISSAO is required")]
        public DateTime? DtAdmissao { get; set; } // date, not null

        [Column("DT_DEMISSAO", TypeName = "date")]
        public DateTime? DtDemissao { get; set; } // date, null

        [Column("SEXO", TypeName = "int")] public int? Sexo { get; set; } // int, null

        [Column("MATRICULA", TypeName = "varchar")]
        [MaxLength(30)]
        [Required(ErrorMessage = "MATRICULA is required")]
        public string Matricula { get; set; } // varchar(30), not null

        [Column("NOME_REDE", TypeName = "varchar")]
        [MaxLength(150)]
        public string NomeRede { get; set; } // varchar(150), null

        [Column("SITUACAO_FOLHA", TypeName = "varchar")]
        [MaxLength(200)]
        public string SituacaoFolha { get; set; } // varchar(200), null

        [Column("COD_LEGADO", TypeName = "int")]
        public int? CodLegado { get; set; } // int, null

        [Column("ID_USU_CAD", TypeName = "int")]
        [Required(ErrorMessage = "ID USU CAD is required")]
        [IdNotZeroValidation]
        public int? IdUsuCad { get; set; } // int, not null

        [Column("DT_CAD", TypeName = "datetime")]
        [Required(ErrorMessage = "DT CAD is required")]
        public DateTime? DtCad { get; set; } // datetime, not null

        [Column("DT_ULT_ALT", TypeName = "datetime")]
        public DateTime? DtUltAlt { get; set; } // datetime, null

        public BaLogradouro BaLogradouro { get; set; } // int, null
        public virtual IEnumerable<BaLogradouro> BaLogradouros { get; set; }
        public virtual IEnumerable<BaCargo> BaCargos { get; set; }
        public virtual IEnumerable<BaFilial> BaFiliais { get; set; }
        public virtual IEnumerable<BaUsuFilial> BaUsuFiliais { get; set; }
        public virtual IEnumerable<BaTipoCargo> BaTipoCargos { get; set; }
        public virtual IEnumerable<BaUsuPermissao> BaUsuPermissoes { get; set; }

        public override string Value => NomeUsu;
    }
}