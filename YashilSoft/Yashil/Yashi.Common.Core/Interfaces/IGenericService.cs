using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using Yashil.Common.Core.Classes;

namespace Yashil.Common.Core.Interfaces
{
    public interface IGenericService<TModel> where TModel : class
    {
        void Delete(TModel entity, bool saveAfterDelete = false);
        void Delete(object id, bool saveAfterDelete = false);
        Task<TModel> AddAsync(TModel t, bool saveAfterAdd = false);
        Task<ValueTask<TModel>?> UpdateAsync(TModel t, object key, List<string> modifiedProperties, bool saveAfterUpdate = false);
        Task<TViewModel> GetAsync<TViewModel>(IMapper mapper, object id, bool readOnly);
        Task<List<TViewModel>> GetAllAsync<TViewModel>(IMapper mapper, bool readOnly = false);
        Task<int> CountAsync();

        Task<LoadResult> GetAllAsync<TViewModel>(IMapper mapper, CustomDataSourceLoadOptions loadOptions,
            bool readOnly = false);

        Task<int> SaveChangeAsync();
    }
}