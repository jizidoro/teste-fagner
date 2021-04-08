#region

using System;
using kpmg.Application.Bases;

#endregion

namespace kpmg.Application.Dtos
{
    public class AirplaneDto : EntityDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public int QuantidadePassageiros { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}