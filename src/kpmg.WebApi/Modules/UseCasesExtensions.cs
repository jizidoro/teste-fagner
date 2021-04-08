#region

using kpmg.Application.Interfaces;
using kpmg.Application.Services;
using kpmg.Core.AirplaneCore.Usecase;
using kpmg.Core.AirplaneCore.Validation;
using kpmg.Core.BaUsuCore.Usecase;
using kpmg.Core.BaUsuCore.Validation;
using kpmg.Core.SecurityCore.Usecase;
using kpmg.Core.SecurityCore.Validation;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace kpmg.WebApi.Modules
{
    /// <summary>
    ///     Adds Use Cases classes.
    /// </summary>
    public static class UseCasesExtensions
    {
        /// <summary>
        ///     Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            #region Autenticacao

            services.AddScoped<IAutenticacaoAppService, AutenticacaoAppService>();

            #endregion

            #region Airplane

            // Application - Services
            services.AddScoped<IAirplaneAppService, AirplaneAppService>();

            // Core - Usecases
            services.AddScoped<AirplaneEditarUsecase>();
            services.AddScoped<AirplaneIncluirUsecase>();
            services.AddScoped<AirplaneExcluirUsecase>();

            // Core - Validations
            services.AddScoped<AirplaneValidarEditar>();
            services.AddScoped<AirplaneValidarExcluir>();
            services.AddScoped<AirplaneValidarIncluir>();
            services.AddScoped<AirplaneValidarCodigoRepetido>();

            #endregion

            #region BaUsu

            // Application - Services
            services.AddScoped<IBaUsuAppService, BaUsuAppService>();

            // Core - Usecases
            services.AddScoped<AtualizarSenhaExpiradaUsecase>();
            services.AddScoped<GerarTokenLoginUsecase>();
            services.AddScoped<EsquecerSenhaUsecase>();
            services.AddScoped<BaUsuValidarEsquecerSenha>();
            services.AddScoped<BaUsuValidarSenha>();
            services.AddScoped<BaUsuEditarUsecase>();
            services.AddScoped<BaUsuIncluirUsecase>();
            services.AddScoped<BaUsuExcluirUsecase>();

            // Core - Validations
            services.AddScoped<BaUsuValidarEditar>();
            services.AddScoped<BaUsuValidarExcluir>();
            services.AddScoped<BaUsuValidarIncluir>();
            services.AddScoped<BaUsuValidarSenhaExpirada>();

            #endregion

            return services;
        }
    }
}