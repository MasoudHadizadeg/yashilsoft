using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Interfaces;

namespace Yashil.Common.Infrastructure.Implementations
{
    public class GenericService<TModel, TK> : IGenericService<TModel> where TModel : class, IBaseEntity<TK>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TModel> _repository;


        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TModel> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Delete(TModel entity, bool saveAfterDelete = false)
        {
            _repository.Delete(entity);
            if (saveAfterDelete)
            {
                _unitOfWork.CommitAsync();
            }
        }

        public async Task Delete(object id, bool saveAfterDelete = false)
        {
            _repository.Delete(id);
            if (saveAfterDelete)
            {
                await _unitOfWork.CommitAsync();
            }
        }

        public virtual async Task<TModel> AddAsync(TModel t, bool saveAfterAdd = false)
        {
            var addedEntity = await _repository.AddAsync(t);
            if (saveAfterAdd)
            {
                await _unitOfWork.CommitAsync();
            }

            return addedEntity;
        }

        public TModel Add(TModel t, bool saveAfterAdd = false)
        {
            var addedEntity =  _repository.Add(t);
            if (saveAfterAdd)
            {
                 _unitOfWork.Commit();
            }

            return addedEntity;
        }

        public virtual async Task<ValueTask<TModel>?> UpdateAsync(TModel t, object key, List<string> modifiedProperties,
            bool saveAfterUpdate = false)
        {
            var updateAsync = await _repository.UpdateAsync(t, key, modifiedProperties);
            if (saveAfterUpdate)
            {
                await _unitOfWork.CommitAsync();
            }

            return updateAsync;
        }

        public async Task<TModel> GetAsync(object id, bool readOnly)
        {
            return await _repository.GetAsync(id, readOnly);
        }


        public virtual async Task<TViewModel> GetAsync<TViewModel>(IMapper mapper, object id, bool readOnly)
        {
            var valueTask = await _repository.GetAsync(id, readOnly);
            return mapper.Map<TViewModel>(valueTask);
        }

        public TModel Get(object id, bool readOnly=false)
        {
            return _repository.Get(id, readOnly);
            
        }

        public virtual async Task<List<TViewModel>> GetAllAsync<TViewModel>(IMapper mapper, bool readOnly = false)
        {
            return await _repository.GetAll(readOnly).ProjectTo<TViewModel>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _repository.CountAsync();
        }

        public virtual async Task<int> SaveChangeAsync()
        {
            return await _unitOfWork.CommitAsync();
        }

        public IQueryable<TModel> GetAll(bool readOnly)
        {
            return _repository.GetAll(readOnly);
        }
    }
}