			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilNews.Core.Repositories;

namespace YashilNews.Infrastructure.RepositoryImpl
{
	public class MainNewsRepository : GenericApplicationBasedRepository<MainNews,int>, IMainNewsRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public MainNewsRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }

        
        public IQueryable<MainNews> GetByNewsStoreId(int newsStoreId)
        {
            return GetAll(true).Where(x => x.NewsStoreId == newsStoreId);
        }
      
        public IQueryable<MainNews> GetByNewsPropertyId(int newsPropertyId)
        {
            return GetAll(true).Where(x => x.NewsPropertyId == newsPropertyId);
        }
      
        public IQueryable<MainNews> GetByCreateBy(int createBy)
        {
            return GetAll(true).Where(x => x.CreateBy == createBy);
        }
      
        public IQueryable<MainNews> GetByModifyBy(int modifyBy)
        {
            return GetAll(true).Where(x => x.ModifyBy == modifyBy);
        }
      
        public IQueryable<MainNews> GetByApplicationId(int applicationId)
        {
            return GetAll(true).Where(x => x.ApplicationId == applicationId);
        }
      
        public IQueryable<MainNews> GetByCreatorOrganizationId(int creatorOrganizationId)
        {
            return GetAll(true).Where(x => x.CreatorOrganizationId == creatorOrganizationId);
        }
          
    }
}      
