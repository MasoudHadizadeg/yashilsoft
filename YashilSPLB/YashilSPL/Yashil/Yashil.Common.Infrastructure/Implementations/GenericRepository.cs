using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Dtos;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Common.Infrastructure.Implementations
{
    public abstract class GenericRepository<T, TR> : IGenericRepository<T,TR>
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

        public virtual T Get(object id, bool readOnly = false)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual ValueTask<T> GetAsync(object id, bool readOnly = true)
        {
            return _context.Set<T>().FindAsync(id);
        }

        public virtual Task<IEnumerable<T>> GetAllAsync(bool readOnly = false)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll(bool readOnly = false)
        {
            return readOnly ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
        }

        public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
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

        public virtual T Add(T t)
        {
            t.CreateBy = _userPrincipal.Id;
            t.CreationDate = DateTime.Now;

            _context.Set<T>().Add(t);
            return t;
        }

        public virtual async Task<T> AddAsync(T t)
        {

            t.CreateBy = _userPrincipal.Id;
            t.CreationDate = DateTime.Now;

            await _context.Set<T>().AddAsync(t);
            return t;
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            // _context.SaveChanges();
        }

        public virtual void Delete(object id, bool logical = false)
        {
            var firstOrDefault = _context.Set<T>().Find(id);

            if (firstOrDefault != null)
            {
                if (!logical)
                {
                    _context.Set<T>().Remove(firstOrDefault);
                }
                else
                {
                    firstOrDefault.Deleted = true;
                }
            }
        }

        public virtual T Update(T t, object key)
        {
            return Update(t, key, null, false);
        }

        public virtual T Update(T t, object key, List<string> props, bool modifyProps = true)
        {
            if (t == null)
                return null;
            var exist = _context.Set<T>().Find(key);
            var existResult = exist;
            if (existResult != null)
            {
                var entityEntry = _context.Entry(existResult);
                entityEntry.CurrentValues.SetValues(t);

                SetDefaultReadOnlyProps(entityEntry);

                if (props != null && props.Count > 0)
                {
                    var notModifiedProperties = entityEntry.Properties.Where(m => m.IsModified &&
                                                                                  (modifyProps &&
                                                                                   !props.Contains(m.Metadata.Name)) ||
                                                                                  (!modifyProps &&
                                                                                   props.Contains(m.Metadata.Name)))
                        .ToList();
                    foreach (var notModifiedProperty in notModifiedProperties)
                    {
                        entityEntry.Property(notModifiedProperty.Metadata.Name).IsModified = false;
                    }
                }
            }

            return exist;
        }

        private void SetDefaultReadOnlyProps(EntityEntry<T> entityEntry)
        {
            entityEntry.Property("CreationDate").IsModified = false;
            entityEntry.Property("CreateBy").IsModified = false;

            var creatorOrganizationId = entityEntry.Property("CreatorOrganizationId");
            if (creatorOrganizationId != null)
            {
                creatorOrganizationId.IsModified = false;
            }

            var applicationId = entityEntry.Property("ApplicationId");
            if (applicationId != null)
            {
                applicationId.IsModified = false;
            }
        }

        public virtual async Task<ValueTask<T>?> UpdateAsync(T t, object key)
        {
            return await UpdateAsync(t, key, null, false);
        }


        public virtual async Task<ValueTask<T>?> UpdateAsync(T t, object key, List<string> props, bool modifyProps = true)
        {
            if (t == null)
                return null;
            var exist = await _context.Set<T>().FindAsync(key);
            var existResult = exist;
            if (existResult != null)
            {
                var entityEntry = _context.Entry(existResult);
                entityEntry.CurrentValues.SetValues(t);

                SetDefaultReadOnlyProps(entityEntry);

                if (props != null && props.Count > 0)
                {
                    var notModifiedProperties = entityEntry.Properties.Where(m => m.IsModified &&
                                                                                  (modifyProps &&
                                                                                   !props.Contains(m.Metadata.Name)) ||
                                                                                  (!modifyProps &&
                                                                                   props.Contains(m.Metadata.Name))).ToList();
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

        public virtual async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public string GetEntityDescriptionByPropName(TR key, string propName)
        {

            var property = typeof(T).GetProperty(propName);
            if (property != null)
            {
                return DbSet.Where(x => x.Id.Equals(key)).Select(x => EF.Property<string>(x, "Topic")).FirstOrDefault();
            }

            return null;

        }
        // var propertyInfo = DbSet.GetType().GetProperty("Topic");

        //return DbSet.Where(x => x.Id == id).Select(x => x.Topic).FirstOrDefault();


    }
}