#region

using System;
using kpmg.Application.Bases;

#endregion

namespace kpmg.Application.Dtos
{
    public class BaUsuDto : EntityDto
    {
        public int? Id { get; set; }
        public string NomeUsu { get; set; }
        public string Cpf { get; set; }
        public DateTime? DtNasc { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        public int? IdLogradouro { get; set; }
        public int? NrLogradouro { get; set; }
        public string CplLogradouro { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? UltAltSenha { get; set; }
        public int? StsUsu { get; set; }
        public int? CodCargo { get; set; }
        public DateTime? DtAdmissao { get; set; }
        public DateTime? DtDemissao { get; set; }
        public int? Sexo { get; set; }
        public string Matricula { get; set; }
        public string NomeRede { get; set; }
        public string SituacaoFolha { get; set; }
        public int? CodLegado { get; set; }
        public int? IdUsuCad { get; set; }
        public DateTime? DtCad { get; set; }
        public DateTime? DtUltAlt { get; set; }
    }
}