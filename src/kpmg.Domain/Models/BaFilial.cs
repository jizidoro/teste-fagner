#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_FILIAL")]
    public class BaFilial : Entity
    {
        [Column("RAZAO_SOCIAL", TypeName = "varchar")]
        [MaxLength(200)]
        [Required(ErrorMessage = "RAZAO SOCIAL is required")]
        public string RazaoSocial { get; set; } // varchar(200), not null

        [Column("NOME_FANTASIA", TypeName = "varchar")]
        [MaxLength(200)]
        [Required(ErrorMessage = "NOME FANTASIA is required")]
        public string NomeFantasia { get; set; } // varchar(200), not null

        [Column("SIGLA_FILIAL", TypeName = "varchar")]
        [MaxLength(3)]
        [Required(ErrorMessage = "SIGLA FILIAL is required")]
        public string SiglaFilial { get; set; } // varchar(3), not null

        [Column("NOME_LISTA", TypeName = "varchar")]
        [MaxLength(100)]
        [Required(ErrorMessage = "NOME LISTA is required")]
        public string NomeLista { get; set; } // varchar(100), not null

        [Column("ID_LOGRADOURO", TypeName = "int")]
        public int? IdLogradouro { get; set; } // int, null

        [Column("NR_LOGRADOURO", TypeName = "varchar")]
        [MaxLength(10)]
        public string NrLogradouro { get; set; } // varchar(10), null

        [Column("CPL_LOGRADOURO", TypeName = "varchar")]
        [MaxLength(100)]
        public string CplLogradouro { get; set; } // varchar(100), null

        [Column("CNPJ", TypeName = "varchar")]
        [MaxLength(14)]
        [Required(ErrorMessage = "CNPJ is required")]
        public string Cnpj { get; set; } // varchar(14), not null

        [Column("INSC_MUNI", TypeName = "varchar")]
        [MaxLength(30)]
        public string InscMuni { get; set; } // varchar(30), null

        [Column("INSC_EST", TypeName = "varchar")]
        [MaxLength(30)]
        [Required(ErrorMessage = "INSC EST is required")]
        public string InscEst { get; set; } // varchar(30), not null

        [Column("TIPO_FILIAL", TypeName = "int")]
        [Required(ErrorMessage = "TIPO FILIAL is required")]
        public int TipoFilial { get; set; } // int, not null

        [Column("STS_FILIAL", TypeName = "int")]
        [Required(ErrorMessage = "STS FILIAL is required")]
        public int StsFilial { get; set; } // int, not null

        [Column("LOJA_ABERTA", TypeName = "int")]
        [Required(ErrorMessage = "LOJA ABERTA is required")]
        public int LojaAberta { get; set; } // int, not null

        [Column("LOJA_24H", TypeName = "int")]
        [Required(ErrorMessage = "LOJ A 24 H is required")]
        public int Loja24H { get; set; } // int, not null

        [Column("DT_INAUGURACAO", TypeName = "date")]
        public DateTime? DtInauguracao { get; set; } // date, null

        [Column("ORDEM_SEQ_FILIAL", TypeName = "int")]
        [Required(ErrorMessage = "ORDEM SEQ FILIAL is required")]
        public int OrdemSeqFilial { get; set; } // int, not null

        [Column("REGIME_TRIBUTARIO", TypeName = "int")]
        public int? RegimeTributario { get; set; } // int, null

        [Column("COD_EMPRESA_CONTABIL", TypeName = "varchar")]
        [MaxLength(20)]
        public string CodEmpresaContabil { get; set; } // varchar(20), null

        [Column("COD_CENTRO_CUSTO_CONTABIL", TypeName = "varchar")]
        [MaxLength(20)]
        public string CodCentroCustoContabil { get; set; } // varchar(20), null

        [Column("METRAGEM_FILIAL", TypeName = "money")]
        public decimal? MetragemFilial { get; set; } // money, null

        [Column("ID_REDE", TypeName = "int")]
        [Required(ErrorMessage = "ID REDE is required")]
        public int IdRede { get; set; } // int, not null

        [Column("ID_GRUPO_ECONOMICO", TypeName = "int")]
        [Required(ErrorMessage = "ID GRUPO ECONOMICO is required")]
        public int IdGrupoEconomico { get; set; } // int, not null

        [Column("CONNECT_D1000", TypeName = "int")]
        [Required(ErrorMessage = "CONNECT D1000 is required")]
        public int ConnectD1000 { get; set; } // int, not null

        [Column("ID_USU", TypeName = "int")]
        [Required(ErrorMessage = "ID USU is required")]
        public int IdUsu { get; set; } // int, not null

        [Column("DT_CAD", TypeName = "datetime")]
        [Required(ErrorMessage = "DT CAD is required")]
        public DateTime DtCad { get; set; } // datetime, not null

        [Column("DT_ULT_ALT", TypeName = "datetime")]
        public DateTime? DtUltAlt { get; set; } // datetime, null

        public virtual BaLogradouro BaLogradouro { get; set; }

        public virtual BaUsu BaUsu { get; set; }
        public virtual IEnumerable<BaUsuFilial> BaUsuFiliais { get; set; }
    }
}