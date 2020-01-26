using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Common.Infrastructure.Implementations
{
    public abstract class GenericRepository<T, TR> : IGenericRepository<T>
        where T : class, IBaseEntity<TR> where TR : IEquatable<TR>
    {
        private readonly DbContext _context;
        protected readonly DbSet<T> DbSet;
        private readonly IUserPrincipal _userPrincipal;

        public GenericRepository(DbContext context, IUserPrincipal userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
            DbSet = _context.Set<T>();
        }

        #region public Select Methods For Service Classes

        public T Get(object id, bool readOnly = false)
        {
            return _context.Set<T>().Find(id);
        }

        public ValueTask<T> GetAsync(object id, bool readOnly = true)
        {
            return _context.Set<T>().FindAsync(id);
        }

        public Task<IEnumerable<T>> GetAllAsync(bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(bool readOnly = false)
        {
            return readOnly ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var queryable = GetAll();
            foreach (var includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        #endregion

        #region private Select Methods For Repository Classes

        private T Find(Expression<Func<T, bool>> match, bool readOnly = false)
        {
            return readOnly
                ? _context.Set<T>().AsNoTracking().SingleOrDefault(match)
                : _context.Set<T>().SingleOrDefault(match);
        }

        private async Task<T> FindAsync(Expression<Func<T, bool>> match, bool readOnly = false)
        {
            return readOnly
                ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(match)
                : await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        private ICollection<T> FindAll(Expression<Func<T, bool>> match, bool readOnly = false)
        {
            return readOnly
                ? _context.Set<T>().AsNoTracking().Where(match).ToList()
                : _context.Set<T>().Where(match).ToList();
        }

        private async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match, bool readOnly = false)
        {
            return readOnly
                ? await _context.Set<T>().AsNoTracking().Where(match).ToListAsync()
                : await _context.Set<T>().Where(match).ToListAsync();
        }

        private IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, bool readOnly = false)
        {
            return readOnly ? _context.Set<T>().AsNoTracking().Where(predicate) : _context.Set<T>().Where(predicate);
        }

        private async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate,
            bool readOnly = false)
        {
            return readOnly
                ? await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync()
                : await _context.Set<T>().Where(predicate).ToListAsync();
        }

        #endregion

        #region Add And Update Methods

        public T Add(T t)
        {
            _context.Set<T>().Add(t);
            return t;
        }

        public async Task<T> AddAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
            return t;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            // _context.SaveChanges();
        }

        public void Delete(object id)
        {
            var firstOrDefault = _context.Set<T>().Find(id);
            if (firstOrDefault != null) _context.Set<T>().Remove(firstOrDefault);
        }

        public T Update(T t, object key, List<string> modifiedProperties)
        {
            if (t == null)
                return null;
            var exist = _context.Set<T>().Find(key);
            var existResult = exist;
            if (existResult != null)
            {
                var entityEntry = _context.Entry(existResult);
                entityEntry.CurrentValues.SetValues(t);

                entityEntry.Property("CreationDate").IsModified = false;
                entityEntry.Property("CreateBy").IsModified = false;

                if (modifiedProperties != null && modifiedProperties.Count > 0)
                {
                    var notModifiedProperties = entityEntry.Properties
                        .Where(m => m.IsModified &&
                                    !modifiedProperties.Contains(m.Metadata.Name))
                        .ToList();
                    foreach (var notModifiedProperty in notModifiedProperties)
                    {
                        entityEntry.Property(notModifiedProperty.Metadata.Name).IsModified = false;
                    }
                }
            }

            return exist;
        }

        public async Task<ValueTask<T>?> UpdateAsync(T t, object key, List<string> notModifiedProps)
        {
            if (t == null)
                return null;
            var exist = await _context.Set<T>().FindAsync(key);
            var existResult = exist;
            if (existResult != null)
            {
                var entityEntry = _context.Entry(existResult);
                entityEntry.CurrentValues.SetValues(t);

                entityEntry.Property("CreationDate").IsModified = false;
                entityEntry.Property("CreateBy").IsModified = false;

                if (notModifiedProps != null && notModifiedProps.Count > 0)
                {
                    var notModifiedProperties = entityEntry.Properties
                        .Where(m => m.IsModified &&
                                    !notModifiedProps.Contains(m.Metadata.Name))
                        .ToList();
                    foreach (var notModifiedProperty in notModifiedProperties)
                    {
                        entityEntry.Property(notModifiedProperty.Metadata.Name).IsModified = false;
                    }
                }
            }

            return new ValueTask<T>(exist);
        }

        #endregion

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}