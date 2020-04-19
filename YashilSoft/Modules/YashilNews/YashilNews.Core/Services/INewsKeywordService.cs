
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilNews.Core.Services
{
	public interface INewsKeywordService : IGenericService<NewsKeyword,int>
    {
		
        IQueryable<NewsKeyword> GetByNewsStoreId(int newsStoreId);
      
        IQueryable<NewsKeyword> GetByKeywordId(int keywordId);
      
        IQueryable<NewsKeyword> GetByCreateBy(int createBy);
      
        IQueryable<NewsKeyword> GetByModifyBy(int modifyBy);
      
        IQueryable<NewsKeyword> GetByApplicationId(int applicationId);
      
        IQueryable<NewsKeyword> GetByAccessLevelId(int accessLevelId);
      
        IQueryable<NewsKeyword> GetByCreatorOrganizationId(int creatorOrganizationId);
          
		
    }
}      
 