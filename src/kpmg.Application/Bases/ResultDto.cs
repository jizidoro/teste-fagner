#region

using System.Collections.Generic;
using kpmg.Application.Utils;

#endregion

namespace kpmg.Application.Bases
{
    public class ResultDto : IResultDto
    {
        public int Codigo { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public IList<string> Mensagens { get; set; }
    }
}