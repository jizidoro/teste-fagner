﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using kpmg.Application.Bases;
using kpmg.Application.Interfaces;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Domain.Bases;
using Microsoft.EntityFrameworkCore;

#endregion

namespace kpmg.Application.Services
{
    public class LookupServiceApp<TEntity> : AppService, ILookupServiceApp<TEntity>
        where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;

        public LookupServiceApp(IRepository<TEntity> repository, IMapper mapper)
            : base(mapper)
        {
            _repository = repository;
        }

        public async Task<IList<LookupDto>> ObterLookup()
        {
            var lista = await Task.Run(() => _repository.GetLookup()
                .ProjectTo<LookupDto>(Mapper.ConfigurationProvider)
                .ToListAsync());

            if (lista != null)
            {
                return lista.OrderBy(x => x.Value).ToList();
            }

            return new List<LookupDto>();
        }

        public async Task<IList<LookupDto>> ObterLookup(Expression<Func<TEntity, bool>> predicate)
        {
            var lista = await Task.Run(() => _repository.GetLookup(predicate)
                .ProjectTo<LookupDto>(Mapper.ConfigurationProvider)
                .ToListAsync());

            return lista;
        }
    }
}