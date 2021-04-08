#region

using System;
using kpmg.Domain.Bases;

#endregion

namespace kpmg.Domain.Models
{
    public class Airplane : Entity
    {
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public int QuantidadePassageiros { get; set; }
        public DateTime DataRegistro { get; set; }

        public override string Value => Codigo;
    }
}