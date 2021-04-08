#region

using System.Threading.Tasks;
using kpmg.Core.Helpers.Interfaces;
using kpmg.Core.Helpers.Models.Results;
using kpmg.Core.Helpers.Models.Validations;
using kpmg.Domain.Models;

#endregion

namespace kpmg.Core.BaUsuCore.Validation
{
    public class BaUsuValidarIncluir : EntityValidation<BaUsu>
    {
        private readonly IBaUsuRepository _repository;

        public BaUsuValidarIncluir(IBaUsuRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<ISingleResult<BaUsu>> Execute(BaUsu entity)
        {
            return new SingleResult<BaUsu>(entity);
        }
    }
}