namespace kpmg.Domain.Models.Views
{
    public class VBaUsuPermissao
    {
        public int IdUsu { get; set; } // int, not null

        public int GrupoUsu { get; set; } // int, not null

        public bool? Adm { get; set; } // bit, null

        public int? Modulo { get; set; } // int, null

        public int? Tela { get; set; } // int, null

        public int? Permissao { get; set; } // int, null
    }
}