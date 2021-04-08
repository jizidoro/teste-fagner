#region

using System.Collections.Generic;

#endregion

namespace kpmg.Core.Utils
{
    public class User
    {
        public string Chave { get; set; }
        public string NomeUsuario { get; set; }
        public string Token { get; set; }
        public IList<string> Papeis { get; set; }
        public IList<string> Permissoes { get; set; }
        public IList<string> Filiais { get; set; }
    }
}