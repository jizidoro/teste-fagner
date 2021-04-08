#region

using System.Collections.Generic;
using kpmg.Application.Services;
using kpmg.Core.BaUsuCore.Validation;
using kpmg.Core.SecurityCore.Usecase;
using kpmg.Core.SecurityCore.Validation;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.Infrastructure.Repositories.Views;
using kpmg.UnitTests.Helpers;
using Microsoft.Extensions.Configuration;

#endregion

namespace kpmg.UnitTests.Tests.BaUsuTests.Bases
{
    public sealed class AutenticacaoInjectionUseCase
    {
        public AtualizarSenhaExpiradaUsecase ObterAtualizarSenhaExpiradaUsecase(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var baUsuCoreRepository = new BaUsuRepository(context);

            var baUsuCoreValidarEditar =
                new BaUsuValidarEditar(baUsuCoreRepository
                );

            return new AtualizarSenhaExpiradaUsecase(baUsuCoreRepository,
                baUsuCoreValidarEditar, uow);
        }

        public EsquecerSenhaUsecase ObterEsquecerSenhaUsecase(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var baUsuCoreRepository = new BaUsuRepository(context);
            var baUsuValidarEditar = new BaUsuValidarEditar(baUsuCoreRepository);
            var baUsuValidarEsquecerSenha =
                new BaUsuValidarEsquecerSenha(baUsuCoreRepository, baUsuValidarEditar
                );


            return new EsquecerSenhaUsecase(baUsuCoreRepository, baUsuValidarEsquecerSenha, uow);
        }

        public GerarTokenLoginUsecase ObterGerarTokenLoginUsecase(KpmgContext context)
        {
            var myConfiguration = new Dictionary<string, string>
            {
                {"JWT:Key", "afsdkjasjflxswafsdklk434orqiwup3457u-34oewir4irroqwiffv48mfs"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();


            var uow = new UnitOfWork(context);
            var baUsuCoreRepository = new BaUsuRepository(context);
            var baUsuParamRepository = new BaParamRepository(context);
            var baUsuValidarSenhaExpirada =
                new BaUsuValidarSenhaExpirada(baUsuCoreRepository, baUsuParamRepository);
            var baUsuValidarSenha =
                new BaUsuValidarSenha(baUsuCoreRepository, baUsuValidarSenhaExpirada);
            var baCargoRepository =
                new BaCargoRepository(context);
            var baUsuFilialRepository =
                new BaUsuFilialRepository(context);
            var vBaUsuPermissaoRepository =
                new VBaUsuPermissaoRepository(context);
            var gerarTokenLoginUsecase =
                new GerarTokenLoginUsecase
                (
                    configuration,
                    baUsuValidarSenha,
                    baCargoRepository,
                    baUsuFilialRepository,
                    vBaUsuPermissaoRepository
                );
            return gerarTokenLoginUsecase;
        }

        private AutenticacaoAppService ObterBaUsuAppService(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var vBaUsuRepository = new VBaUsuPermissaoRepository(context);
            var mapper = MapperHelper.ConfigMapper();

            var oterAtualizarSenhaExpiradaUsecase = ObterAtualizarSenhaExpiradaUsecase(context);
            var obterEsquecerSenhaUsecase = ObterEsquecerSenhaUsecase(context);
            var obterGerarTokenLoginUsecaseUsecase = ObterGerarTokenLoginUsecase(context);

            var autenticacaoAppService = new AutenticacaoAppService(vBaUsuRepository,
                oterAtualizarSenhaExpiradaUsecase,
                obterGerarTokenLoginUsecaseUsecase, obterEsquecerSenhaUsecase, mapper);
            return autenticacaoAppService;
        }
    }
}