#region

using kpmg.Application.Dtos;

#endregion

namespace kpmg.Application.Validations.BaUsuValitation
{
    public class BaUsuEditarValidation : BaUsuValidation<BaUsuEditarDto>
    {
        public BaUsuEditarValidation()
        {
            ValidarId();
            ValidarNomeUsu();
            ValidarCpf();
            ValidarTelefone1();
            ValidarTelefone2();
            ValidarTelefone3();
            ValidarIdLogradouro();
            ValidarCplLogradouro();
            ValidarNomeRede();
            ValidarEmail();
            ValidarSenha();
            ValidarStsUsu();
            ValidarCodCargo();
            ValidarDtAdmissao();
            ValidarMatricula();
            ValidarSituacaoFolha();
            ValidarIdUsuCad();
            ValidarDtCad();
            ValidarNrLogradouro();
        }
    }
}