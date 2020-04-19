			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilNews.Core.Repositories;

namespace YashilNews.Infrastructure.RepositoryImpl
{
	public class ServiceRepository : GenericApplicationBasedRepository<Service,int>, IServiceRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public ServiceRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }

        
        public IQueryable<Service> GetByParentId(int parentId)
        {
            return GetAll(true).Where(x => x.ParentId == parentId);
        }
      
        public IQueryable<Service> GetByAppEntityId(int appEntityId)
        {
            return GetAll(true).Where(x => x.AppEntityId == appEntityId);
        }
      
        public IQueryable<Service> GetByCreateBy(int createBy)
        {
            return GetAll(true).Where(x => x.CreateBy == createBy);
        }
      
        public IQueryable<Service> GetByModifyBy(int modifyBy)
        {
            return GetAll(true).Where(x => x.ModifyBy == modifyBy);
        }
      
        public IQueryable<Service> GetByApplicationId(int applicationId)
        {
            return GetAll(true).Where(x => x.ApplicationId == applicationId);
        }
      
        public IQueryable<Service> GetByAccessLevelId(int accessLevelId)
        {
            return GetAll(true).Where(x => x.AccessLevelId == accessLevelId);
        }
      
        public IQueryable<Service> GetByCreatorOrganizationId(int creatorOrganizationId)
        {
            return GetAll(true).Where(x => x.CreatorOrganizationId == creatorOrganizationId);
        }
          
    }
}      
