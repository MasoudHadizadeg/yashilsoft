			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilNews.Core.Repositories
{
	public interface INewsStoreRepository : IGenericRepository<NewsStore,int>
    {
		
		IQueryable<NewsStore> GetByServiceId(int serviceId);
		
		IQueryable<NewsStore> GetByNewsType(int newsType);
		
		IQueryable<NewsStore> GetByLanguage(int language);
		
		IQueryable<NewsStore> GetByCreateBy(int createBy);
		
		IQueryable<NewsStore> GetByModifyBy(int modifyBy);
		
		IQueryable<NewsStore> GetByApplicationId(int applicationId);
		
		IQueryable<NewsStore> GetByAccessLevelId(int accessLevelId);
		
		IQueryable<NewsStore> GetByCreatorOrganizationId(int creatorOrganizationId);

        IQueryable<NewsStore> GetByCustomFilter(int? serviceId, int? newsType, int? language);
    }
}      
 