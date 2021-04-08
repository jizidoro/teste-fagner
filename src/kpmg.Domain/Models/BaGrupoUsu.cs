#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_GRUPO_USU")]
    public class BaGrupoUsu : Entity
    {
        [Column("NOME", TypeName = "varchar")]
        [MaxLength(256)]
        [Required(ErrorMessage = "NOME is required")]
        public string Nome { get; set; } // varchar(256), not null

        [Column("DESCRICAO", TypeName = "varchar")]
        [MaxLength(512)]
        [Required(ErrorMessage = "DESCRICAO is required")]
        public string Descricao { get; set; } // varchar(512), not null

        [Column("ADM", TypeName = "bit")]
        [Required(ErrorMessage = "ADM is required")]
        public bool Adm { get; set; } // bit, not null

        [Column("ATIVO", TypeName = "bit")]
        [Required(ErrorMessage = "ATIVO is required")]
        public bool Ativo { get; set; } // bit, not null

        public virtual IEnumerable<BaGrupoUsuPermissao> BaGrupoUsuPermissoes { get; set; }
    }
}