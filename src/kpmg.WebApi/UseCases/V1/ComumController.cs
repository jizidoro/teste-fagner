﻿#region

using System;
using System.Threading.Tasks;
using kpmg.Application.Bases;
using kpmg.Application.Dtos.AirplaneDtos;
using kpmg.Application.Dtos.UsuarioSistemaDtos;
using kpmg.Application.Interfaces;
using kpmg.Domain.Models;
using kpmg.WebApi.Modules.Common.FeatureFlags;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement.Mvc;

#endregion

namespace kpmg.WebApi.UseCases.V1
{
    [FeatureGate(CustomFeature.Comum)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ComumController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUsuarioSistemaAppService _usuarioSistemaAppService;

        public ComumController(IServiceProvider serviceProvider, IUsuarioSistemaAppService usuarioSistemaAppService)
        {
            _serviceProvider = serviceProvider;
            _usuarioSistemaAppService = usuarioSistemaAppService;
        }


        [HttpGet]
        [Route("lookup-usuario-sistema")]
        public async Task<IActionResult> GetLookupUsuarioSistema()
        {
            try
            {
                var service = _serviceProvider.GetService<ILookupServiceApp<UsuarioSistema>>();

                var result = await service?.ObterLookup()!;

                return Ok(new ListResultDto<LookupDto>(result));
            }
            catch (Exception e)
            {
                return Ok(new SingleResultDto<AirplaneDto>(e));
            }
        }

        [HttpGet]
        [Route("lookup-usuario-sistema-por-nome/{nome}")]
        public async Task<IActionResult> GetLookupUsuarioSistemaPorNone(string nome)
        {
            try
            {
                var result = await _usuarioSistemaAppService.BuscarPorNome(nome);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new SingleResultDto<UsuarioSistemaDto>(e));
            }
        }
    }
}