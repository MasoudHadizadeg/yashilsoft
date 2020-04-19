			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilNews.Core.Repositories
{
	public interface IServiceRepository : IGenericRepository<Service,int>
    {
		
		IQueryable<Service> GetByParentId(int parentId);
		
		IQueryable<Service> GetByAppEntityId(int appEntityId);
		
		IQueryable<Service> GetByCreateBy(int createBy);
		
		IQueryable<Service> GetByModifyBy(int modifyBy);
		
		IQueryable<Service> GetByApplicationId(int applicationId);
		
		IQueryable<Service> GetByAccessLevelId(int accessLevelId);
		
		IQueryable<Service> GetByCreatorOrganizationId(int creatorOrganizationId);
		    
    }
}      
 