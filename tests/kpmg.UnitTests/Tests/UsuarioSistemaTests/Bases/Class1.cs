using kpmg.Infrastructure.DataAccess;
using kpmg.UnitTests.Helpers;
using kpmg.WebApi.UseCases.V1.UsuarioSistemaApi;

namespace kpmg.UnitTests.Tests.UsuarioSistemaTests.Bases
{
    public class UsuarioSistemaInjectionController
    {
        private readonly UsuarioSistemaInjectionAppService _usuarioSistemaInjectionAppService = new();
        public UsuarioSistemaController ObterUsuarioSistemaController(KpmgContext context)
        {
            var mapper = MapperHelper.ConfigMapper();
            var usuarioSistemaAppService =
                _usuarioSistemaInjectionAppService.ObterUsuarioSistemaAppService(context, mapper);

            return new UsuarioSistemaController(usuarioSistemaAppService, mapper);
        }
    }
}