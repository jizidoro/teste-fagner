#region

using System.Collections.Generic;
using kpmg.Application.Services;
using kpmg.Core.Helpers.Extensions;
using kpmg.Core.Helpers.Models;
using kpmg.Core.SecurityCore.Usecase;
using kpmg.Core.SecurityCore.Validation;
using kpmg.Core.UsuarioSistemaCore.Validation;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.Infrastructure.Repositories.Views;
using kpmg.UnitTests.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

#endregion

namespace kpmg.UnitTests.Tests.BaUsuTests.Bases
{
    public sealed class AutenticacaoInjectionUseCase
    {
        public AtualizarSenhaExpiradaUsecase ObterAtualizarSenhaExpiradaUsecase(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var usuarioSistemaCoreRepository = new UsuarioSistemaRepository(context);

            var usuarioSistemaCoreValidarEditar =
                new UsuarioSistemaValidarEditar(usuarioSistemaCoreRepository
                );
            var passwordHasher = new PasswordHasher(new HashingOptions());

            return new AtualizarSenhaExpiradaUsecase(usuarioSistemaCoreRepository,
                usuarioSistemaCoreValidarEditar, passwordHasher, uow);
        }

        public EsquecerSenhaUsecase ObterEsquecerSenhaUsecase(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var usuarioSistemaCoreRepository = new UsuarioSistemaRepository(context);
            var usuarioSistemaValidarEditar = new UsuarioSistemaValidarEditar(usuarioSistemaCoreRepository);
            var usuarioSistemaValidarEsquecerSenha =
                new UsuarioSistemaValidarEsquecerSenha(usuarioSistemaCoreRepository, usuarioSistemaValidarEditar
                );
            var passwordHasher = new PasswordHasher(new HashingOptions());

            return new EsquecerSenhaUsecase(usuarioSistemaCoreRepository, usuarioSistemaValidarEsquecerSenha, passwordHasher, uow);
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
            var usuarioSistemaCoreRepository = new UsuarioSistemaRepository(context);
            
            var passwordHasher = new PasswordHasher(new HashingOptions());

            var usuarioSistemaValidarSenha =
                new UsuarioSistemaValidarSenha(usuarioSistemaCoreRepository, passwordHasher);
            var vUsuarioSistemaPermissaoRepository =
                new VwUsuarioSistemaPermissaoRepository(context);
            var gerarTokenLoginUsecase =
                new GerarTokenLoginUsecase
                (
                    configuration,
                    usuarioSistemaValidarSenha
                );
            return gerarTokenLoginUsecase;
        }

        private AutenticacaoAppService ObterUsuarioSistemaAppService(KpmgContext context)
        {
            var uow = new UnitOfWork(context);
            var vUsuarioSistemaRepository = new VwUsuarioSistemaPermissaoRepository(context);
            var mapper = MapperHelper.ConfigMapper();

            var oterAtualizarSenhaExpiradaUsecase = ObterAtualizarSenhaExpiradaUsecase(context);
            var obterEsquecerSenhaUsecase = ObterEsquecerSenhaUsecase(context);
            var obterGerarTokenLoginUsecaseUsecase = ObterGerarTokenLoginUsecase(context);

            var autenticacaoAppService = new AutenticacaoAppService(vUsuarioSistemaRepository,
                oterAtualizarSenhaExpiradaUsecase,
                obterGerarTokenLoginUsecaseUsecase, obterEsquecerSenhaUsecase, mapper);
            return autenticacaoAppService;
        }
    }
}