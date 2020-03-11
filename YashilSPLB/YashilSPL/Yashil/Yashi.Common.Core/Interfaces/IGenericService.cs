using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Dtos;

namespace Yashil.Common.Core.Interfaces
{
    public interface IGenericService<TModel, TK> where TModel : class
    {
        void Delete(TModel entity, bool saveAfterDelete = false);
        Task Delete(object id, bool saveAfterDelete = false);
        Task<TModel> AddAsync(TModel t, bool saveAfterAdd = false);
        TModel Add(TModel t, bool saveAfterAdd = false);
        Task<ValueTask<TModel>?> UpdateAsync(TModel t, object key, List<string> props, bool modifyProps, bool saveAfterUpdate = false);
        Task<ValueTask<TModel>?> UpdateAsync(TModel t, object key, bool saveAfterUpdate = false);
        TModel Update(TModel t, object key, List<string> props, bool modifyProps, bool saveAfterUpdate = false);
        TModel Update(TModel t, object key, bool saveAfterUpdate = false);
        Task<TModel> GetAsync(object id, bool readOnly);
        TModel Get(object id, bool readOnly);
        Task<int> CountAsync();

        IQueryable<TModel> GetAll(bool readOnly = false);

        Task<int> SaveChangeAsync();
        string GetEntityDescriptionByPropName(TK key, string propName);
        Task<bool> UpdateEntityDescription(DescriptionEditModel<TK> editModel);
    }
}