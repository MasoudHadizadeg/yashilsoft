			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilNews.Core.Repositories;

namespace YashilNews.Infrastructure.RepositoryImpl
{
	public class NewsStoreRepository : GenericApplicationBasedRepository<NewsStore,int>, INewsStoreRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public NewsStoreRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }

        
        public IQueryable<NewsStore> GetByServiceId(int serviceId)
        {
            return GetAll(true).Where(x => x.ServiceId == serviceId);
        }
      
        public IQueryable<NewsStore> GetByNewsType(int newsType)
        {
            return GetAll(true).Where(x => x.NewsType == newsType);
        }
      
        public IQueryable<NewsStore> GetByLanguage(int language)
        {
            return GetAll(true).Where(x => x.Language == language);
        }
      
        public IQueryable<NewsStore> GetByCreateBy(int createBy)
        {
            return GetAll(true).Where(x => x.CreateBy == createBy);
        }
      
        public IQueryable<NewsStore> GetByModifyBy(int modifyBy)
        {
            return GetAll(true).Where(x => x.ModifyBy == modifyBy);
        }
      
        public IQueryable<NewsStore> GetByApplicationId(int applicationId)
        {
            return GetAll(true).Where(x => x.ApplicationId == applicationId);
        }
      
        public IQueryable<NewsStore> GetByAccessLevelId(int accessLevelId)
        {
            return GetAll(true).Where(x => x.AccessLevelId == accessLevelId);
        }
      
        public IQueryable<NewsStore> GetByCreatorOrganizationId(int creatorOrganizationId)
        {
            return GetAll(true).Where(x => x.CreatorOrganizationId == creatorOrganizationId);
        }

        public IQueryable<NewsStore> GetByCustomFilter(int? serviceId, int? newsType, int? language)
        {
            var query= GetAll(true);
            if (serviceId.HasValue)
            {
                query = query.Where(x => x.ServiceId == serviceId.Value);
            }
            if (newsType.HasValue)
            {
                query = query.Where(x => x.NewsType == newsType.Value);
            }
            if (language.HasValue)
            {
                query = query.Where(x => x.Language == language.Value);
            }
            return query;
        }
    }
}      
