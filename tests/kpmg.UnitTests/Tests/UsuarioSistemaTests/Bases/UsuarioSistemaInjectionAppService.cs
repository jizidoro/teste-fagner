#region

#endregion

using AutoMapper;
using kpmg.Application.Services;
using kpmg.Core.Helpers.Extensions;
using kpmg.Core.Helpers.Models;
using kpmg.Core.UsuarioSistemaCore.Usecase;
using kpmg.Core.UsuarioSistemaCore.Validation;
using kpmg.Infrastructure.DataAccess;
using kpmg.Infrastructure.Repositories;
using kpmg.UnitTests.Helpers;

namespace kpmg.UnitTests.Tests.UsuarioSistemaTests.Bases
{
    public sealed class UsuarioSistemaInjectionAppService
    {
        public UsuarioSistemaAppService ObterUsuarioSistemaAppService(KpmgContext context, IMapper mapper)
        {
            var uow = new UnitOfWork(context);
            var usuarioSistemaRepository = new UsuarioSistemaRepository(context);
            var passwordHasher = new PasswordHasher(new HashingOptions());

            var usuarioSistemaValidarEditar =
                new UsuarioSistemaValidarEditar(usuarioSistemaRepository);
            var usuarioSistemaValidarExcluir = new UsuarioSistemaValidarExcluir(usuarioSistemaRepository);
            var usuarioSistemaValidarIncluir =
                new UsuarioSistemaValidarIncluir(usuarioSistemaRepository);
            var usuarioSistemaIncluirUsecase =
                new UsuarioSistemaIncluirUsecase(usuarioSistemaRepository, usuarioSistemaValidarIncluir, passwordHasher,
                    uow);
            var usuarioSistemaExcluirUsecase =
                new UsuarioSistemaExcluirUsecase(usuarioSistemaRepository, usuarioSistemaValidarExcluir, uow);
            var usuarioSistemaEditarUsecase =
                new UsuarioSistemaEditarUsecase(usuarioSistemaRepository, usuarioSistemaValidarEditar, uow);

            return new UsuarioSistemaAppService(usuarioSistemaRepository, usuarioSistemaEditarUsecase,
                usuarioSistemaIncluirUsecase,
                usuarioSistemaExcluirUsecase, mapper);
        }
    }
}