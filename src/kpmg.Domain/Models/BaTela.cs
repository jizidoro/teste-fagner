#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    [Table("DML_BA_TELA")]
    public class BaTela : Entity
    {
        [Column("NOME", TypeName = "varchar")]
        [MaxLength(256)]
        [Required(ErrorMessage = "NOME is required")]
        public string Nome { get; set; } // varchar(256), not null

        [Column("DESCRICAO", TypeName = "varchar")]
        [MaxLength(512)]
        [Required(ErrorMessage = "DESCRICAO is required")]
        public string Descricao { get; set; } // varchar(512), not null

        public virtual IEnumerable<BaUsuPermissao> BaUsuPermissoes { get; set; }
        public virtual IEnumerable<BaGrupoUsuPermissao> BaGrupoUsuPermissoes { get; set; }
        public virtual IEnumerable<BaModulosPermissao> BaModulosPermissoes { get; set; }
    }
}