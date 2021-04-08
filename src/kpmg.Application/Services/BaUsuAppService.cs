#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using kpmg.Application.Bases;
using kpmg.Application.Dtos;
using kpmg.Application.Filters;
using kpmg.Application.Interfaces;
using kpmg.Application.Utils;
using kpmg.Application.Validations.BaUsuValitation;
using kpmg.Core.BaUsuCore;
using kpmg.Core.BaUsuCore.Usecase;
using kpmg.Domain.Bases;
using kpmg.Domain.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Application.Services
{
    public class BaUsuAppService : AppService, IBaUsuAppService
    {
        private readonly BaUsuEditarUsecase _editarBaUsuUsecase;
        private readonly BaUsuExcluirUsecase _excluirBaUsuUsecase;
        private readonly BaUsuIncluirUsecase _incluirBaUsuUsecase;
        private readonly IBaUsuRepository _repository;

        public BaUsuAppService(IBaUsuRepository repository,
            BaUsuEditarUsecase editarBaUsuUsecase,
            BaUsuIncluirUsecase incluirBaUsuUsecase,
            BaUsuExcluirUsecase excluirBaUsuUsecase,
            IMapper mapper)
            : base(mapper)
        {
            _repository = repository;
            _editarBaUsuUsecase = editarBaUsuUsecase;
            _incluirBaUsuUsecase = incluirBaUsuUsecase;
            _excluirBaUsuUsecase = excluirBaUsuUsecase;
        }

        public async Task<IPageResultDto<BaUsuDto>> Listar(PaginationFilter paginationFilter = null)
        {
            List<BaUsuDto> lista;
            if (paginationFilter == null)
            {
                lista = await Task.Run(() => _repository.GetAll()
                    .ProjectTo<BaUsuDto>(Mapper.ConfigurationProvider)
                    .ToListAsync());

                return new PageResultDto<BaUsuDto>(lista);
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

            lista = await Task.Run(() => _repository.GetAll().Skip(skip).Take(paginationFilter.PageSize)
                .ProjectTo<BaUsuDto>(Mapper.ConfigurationProvider)
                .ToListAsync());

            return new PageResultDto<BaUsuDto>(paginationFilter, lista);
        }

        public async Task<ListResultDto<LookupDto>> BuscarPorNome(string nome)
        {
            var success = int.TryParse(nome, out var number);
            List<LookupDto> lista = new();

            if (success)
            {
                var entity = await _repository.GetById(number);
                if (entity != null)
                {
                    var dto = Mapper.Map<LookupDto>(new LookupEntity {Key = entity.Id, Value = entity.NomeUsu});
                    lista = new List<LookupDto> {dto};
                }
            }
            else if (!string.IsNullOrEmpty(nome))
            {
                lista = await Task.Run(() => _repository.BuscarPorNome(nome)
                    .ProjectTo<LookupDto>(Mapper.ConfigurationProvider)
                    .ToListAsync());
            }

            return new ListResultDto<LookupDto>(lista);
        }

        public async Task<ISingleResultDto<BaUsuDto>> Obter(int id)
        {
            var entity = await _repository.GetById(id);
            var dto = Mapper.Map<BaUsuDto>(entity);
            return new SingleResultDto<BaUsuDto>(dto);
        }

        public async Task<ISingleResultDto<EntityDto>> Incluir(BaUsuIncluirDto dto)
        {
            var validator = new BaUsuIncluirValidation();

            var results = await validator.ValidateAsync(dto);

            if (!results.IsValid)
            {
                var listaErros = results.Errors.Select(x => x.ErrorMessage);
                return new SingleResultDto<EntityDto>(listaErros);
            }

            var evento = Mapper.Map<BaUsu>(dto);

            var result = await _incluirBaUsuUsecase.Execute(evento);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }

        public async Task<ISingleResultDto<EntityDto>> Editar(BaUsuEditarDto dto)
        {
            var validator = new BaUsuEditarValidation();

            var results = await validator.ValidateAsync(dto);

            if (!results.IsValid)
            {
                var listaErros = results.Errors.Select(x => x.ErrorMessage);
                return new SingleResultDto<EntityDto>(listaErros);
            }

            var evento = Mapper.Map<BaUsu>(dto);

            var result = await _editarBaUsuUsecase.Execute(evento);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }

        public async Task<ISingleResultDto<EntityDto>> Excluir(int id)
        {
            var result = await _excluirBaUsuUsecase.Execute(id);

            var resultDto = new SingleResultDto<EntityDto>(result);
            resultDto.SetData(result, Mapper);

            return resultDto;
        }
    }
}