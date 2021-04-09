﻿#region

using kpmg.Application.Services;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories.Views;
using kpmg.UnitTests.Helpers;

#endregion

namespace kpmg.UnitTests.Tests.AutenticacaoTests.Bases
{
    public class AutenticacaoInjectionAppService
    {
        private readonly AutenticacaoInjectionUseCase _autenticacaoInjectionUseCase = new();

        public AutenticacaoAppService ObterAutenticacaoAppServiceService(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var vUsuarioSistemaRepository = new VwUsuarioSistemaPermissaoRepository(context);
            var mapper = MapperHelper.ConfigMapper();

            var oterAtualizarSenhaExpiradaUsecase =
                _autenticacaoInjectionUseCase.ObterAtualizarSenhaExpiradaUsecase(context);
            var obterEsquecerSenhaUsecase =
                _autenticacaoInjectionUseCase.ObterEsquecerSenhaUsecase(context);
            var obterGerarTokenLoginUsecaseUsecase =
                _autenticacaoInjectionUseCase.ObterGerarTokenLoginUsecase(context);

            var autenticacaoAppService = new AutenticacaoAppService(vUsuarioSistemaRepository,
                oterAtualizarSenhaExpiradaUsecase,
                obterGerarTokenLoginUsecaseUsecase, obterEsquecerSenhaUsecase, mapper);
            return autenticacaoAppService;
        }
    }
}