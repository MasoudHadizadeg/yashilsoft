			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilNews.Core.Repositories
{
	public interface IMainNewsRepository : IGenericRepository<MainNews,int>
    {
		
		IQueryable<MainNews> GetByNewsStoreId(int newsStoreId);
		
		IQueryable<MainNews> GetByNewsPropertyId(int newsPropertyId);
		
		IQueryable<MainNews> GetByCreateBy(int createBy);
		
		IQueryable<MainNews> GetByModifyBy(int modifyBy);
		
		IQueryable<MainNews> GetByApplicationId(int applicationId);
		
		IQueryable<MainNews> GetByCreatorOrganizationId(int creatorOrganizationId);
		    
    }
}      
 