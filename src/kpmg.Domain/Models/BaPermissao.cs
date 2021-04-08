#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_PERMISSAO")]
    public class BaPermissao : Entity
    {
        [Column("NOME", TypeName = "varchar")]
        [MaxLength(256)]
        [Required(ErrorMessage = "NOME is required")]
        public string Nome { get; set; } // varchar(256), not null

        [Column("DESCRICAO", TypeName = "varchar")]
        [MaxLength(512)]
        public string Descricao { get; set; } // varchar(512), null

        public virtual IEnumerable<BaUsuPermissao> BaUsuPermissoes { get; set; }
        public virtual IEnumerable<BaGrupoUsuPermissao> BaGrupoUsuPermissoes { get; set; }
        public virtual IEnumerable<BaModulosPermissao> BaModulosPermissoes { get; set; }
    }
}