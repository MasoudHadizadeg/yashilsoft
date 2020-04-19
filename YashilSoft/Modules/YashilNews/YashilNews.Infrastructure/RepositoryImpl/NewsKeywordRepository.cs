			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilNews.Core.Repositories;

namespace YashilNews.Infrastructure.RepositoryImpl
{
	public class NewsKeywordRepository : GenericApplicationBasedRepository<NewsKeyword,int>, INewsKeywordRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public NewsKeywordRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }

        
        public IQueryable<NewsKeyword> GetByNewsStoreId(int newsStoreId)
        {
            return GetAll(true).Where(x => x.NewsStoreId == newsStoreId);
        }
      
        public IQueryable<NewsKeyword> GetByKeywordId(int keywordId)
        {
            return GetAll(true).Where(x => x.KeywordId == keywordId);
        }
      
        public IQueryable<NewsKeyword> GetByCreateBy(int createBy)
        {
            return GetAll(true).Where(x => x.CreateBy == createBy);
        }
      
        public IQueryable<NewsKeyword> GetByModifyBy(int modifyBy)
        {
            return GetAll(true).Where(x => x.ModifyBy == modifyBy);
        }
      
        public IQueryable<NewsKeyword> GetByApplicationId(int applicationId)
        {
            return GetAll(true).Where(x => x.ApplicationId == applicationId);
        }
      
        public IQueryable<NewsKeyword> GetByAccessLevelId(int accessLevelId)
        {
            return GetAll(true).Where(x => x.AccessLevelId == accessLevelId);
        }
      
        public IQueryable<NewsKeyword> GetByCreatorOrganizationId(int creatorOrganizationId)
        {
            return GetAll(true).Where(x => x.CreatorOrganizationId == creatorOrganizationId);
        }
          
    }
}      
