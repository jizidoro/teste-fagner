#region

using System;
using System.Threading.Tasks;
using AutoMapper;
using kpmg.Application.Bases;
using kpmg.Application.Dtos;
using kpmg.Application.Filters;
using kpmg.Application.Interfaces;
using kpmg.Application.Queries;
using kpmg.WebApi.Modules.Common.FeatureFlags;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

#endregion

namespace kpmg.WebApi.UseCases.V1.BaUsuApi
{
    // [Authorize]
    [FeatureGate(CustomFeature.BaUsu)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaUsuController : ControllerBase
    {
        private readonly IBaUsuAppService _baUsuAppService;
        private readonly IMapper _mapper;

        public BaUsuController(
            IBaUsuAppService baUsuAppService, IMapper mapper)
        {
            _baUsuAppService = baUsuAppService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Listar([FromQuery] PaginationQuery paginationQuery)
        {
            try
            {
                var paginationFilter = _mapper.Map<PaginationQuery, PaginationFilter>(paginationQuery);

                var result = await _baUsuAppService.Listar(paginationFilter);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new SingleResultDto<BaUsuDto>(e));
            }
        }


        [HttpGet]
        [Route("obter/{id:int}")]
        public async Task<IActionResult> Obter(int id)
        {
            try
            {
                var result = await _baUsuAppService.Obter(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new SingleResultDto<BaUsuDto>(e));
            }
        }

        [Route("incluir")]
        [HttpPost]
        public async Task<IActionResult> Incluir([FromBody] BaUsuIncluirDto dto)
        {
            try
            {
                var result = await _baUsuAppService.Incluir(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new SingleResultDto<BaUsuDto>(e));
            }
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] BaUsuEditarDto dto)
        {
            try
            {
                var result = await _baUsuAppService.Editar(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new SingleResultDto<BaUsuDto>(e));
            }
        }

        [HttpDelete]
        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var result = await _baUsuAppService.Excluir(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(new SingleResultDto<BaUsuDto>(e));
            }
        }
    }
}