using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Yashil.Common.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // T Add(T t);
        void Delete(T entity);

        void Delete(object id);

        // T Update(T t, object key, string[] modifiedProperties);
        Task<T> AddAsync(T t);
        ValueTask<T>? UpdateAsync(T t, object key, List<string> modifiedProperties);
        T Get(object id, bool readOnly = false);
        IQueryable<T> GetAll(bool readOnly = false);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        ValueTask<T> GetAsync(object id, bool readOnly = true);
        Task<IEnumerable<T>> GetAllAsync(bool readOnly = false);

        Task<int> CountAsync();

        // int Count();
        void Dispose();
    }
}