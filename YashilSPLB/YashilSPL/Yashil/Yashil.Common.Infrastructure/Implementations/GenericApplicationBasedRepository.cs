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
    public abstract class GenericApplicationBasedRepository<T, TR> : GenericRepository<T, TR>
        where T : class, IBaseEntity<TR>, IApplicationBasedEntity where TR : IEquatable<TR>
    {
        private readonly IUserPrincipal _userPrincipal;

        protected GenericApplicationBasedRepository(DbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _userPrincipal = userPrincipal;
        }

        public override T Add(T t)
        {
            t.ApplicationId = _userPrincipal.ApplicationId;
            t.CreatorOrganizationId = _userPrincipal.OrganizationId;
            return base.Add(t);
        }

        public override Task<T> AddAsync(T t)
        {
            t.ApplicationId = _userPrincipal.ApplicationId;
            t.CreatorOrganizationId = _userPrincipal.OrganizationId;

            return base.AddAsync(t);
        }

        public override void Delete(T entity)
        {
            if (entity.ApplicationId == _userPrincipal.ApplicationId)
            {
                base.Delete(entity);
            }
            else
            {
                throw new AccessViolationException();
                //TODO: Raise Exception
            }
        }

        public override void Delete(object id, bool logical = false)
        {
            var firstOrDefault = DbSet.Find(id);

            if (firstOrDefault != null)
            {
                if (!logical)
                {
                    DbSet.Remove(firstOrDefault);
                }
                else
                {
                    firstOrDefault.Deleted = true;
                }
            }
        }

        public override IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            return base.GetAllIncluding(includeProperties).Where(x => x.ApplicationId == _userPrincipal.ApplicationId);
        }

        public override IQueryable<T> GetAll(bool readOnly = false)
        {
            return base.GetAll(readOnly).Where(x => x.ApplicationId == _userPrincipal.ApplicationId);
        }

        public override Task<IEnumerable<T>> GetAllAsync(bool readOnly = false)
        {
            //TODO :Implement This method
            throw new NotImplementedException();
        }

        public override T Update(T t, object key, List<string> notModifiedProps)
        {
            SetDefaultNotModifiedProps(notModifiedProps);
            return base.Update(t, key, notModifiedProps);
        }

        public override Task<ValueTask<T>?> UpdateAsync(T t, object key, List<string> notModifiedProps)
        {
            SetDefaultNotModifiedProps(notModifiedProps);
            return base.UpdateAsync(t, key, notModifiedProps);
        }

        private void SetDefaultNotModifiedProps(List<string> notModifiedProps)
        {
            if (!notModifiedProps.Contains("CreatorOrganizationId"))
            {
                notModifiedProps.Add("CreatorOrganizationId");
            }
            if (!notModifiedProps.Contains("ApplicationId"))
            {
                notModifiedProps.Add("ApplicationId");
            }

        }
    }
}