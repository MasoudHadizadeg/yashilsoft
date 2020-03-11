using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Yashil.Common.Core.Dtos;

namespace Yashil.Common.Core.Interfaces
{
    public interface IGenericRepository<T, TK> where T : class
    {
        void Delete(T entity);

        void Delete(object id, bool logical = false);

        Task<T> AddAsync(T t);
        T Add(T t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="key"></param>
        /// <param name="props"></param>
        /// <param name="modifyProps"> فقط ویژگی های پاس داده شده ویرایش شود؟ </param>
        /// <returns></returns>
        Task<ValueTask<T>?> UpdateAsync(T t, object key, List<string> props, bool modifyProps = true);
        Task<ValueTask<T>?> UpdateAsync(T t, object key);
        T Update(T t, object key, List<string> props, bool modifyProps = true);
        T Update(T t, object key);

        T Get(object id, bool readOnly = false);
        IQueryable<T> GetAll(bool readOnly = false);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        ValueTask<T> GetAsync(object id, bool readOnly = true);
        Task<int> CountAsync();
        string GetEntityDescriptionByPropName(TK key, string propName);
        Task<bool> UpdateEntityDescription(DescriptionEditModel<TK> editModel);
    }
}