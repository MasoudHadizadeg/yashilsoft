	using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilNews.Core.Repositories;
using YashilNews.Core.Services;

namespace YashilNews.Infrastructure.ServiceImpl
{
	public class NewsKeywordService : GenericService<NewsKeyword,int>, INewsKeywordService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly INewsKeywordRepository _newsKeywordRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public NewsKeywordService (IUnitOfWork unitOfWork, INewsKeywordRepository newsKeywordRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, newsKeywordRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_newsKeywordRepository = newsKeywordRepository;
			_userPrincipal = userPrincipal;
        }
		
        public IQueryable<NewsKeyword> GetByNewsStoreId(int newsStoreId)
        {
            return _newsKeywordRepository.GetByNewsStoreId(newsStoreId);
        }
      
        public IQueryable<NewsKeyword> GetByKeywordId(int keywordId)
        {
            return _newsKeywordRepository.GetByKeywordId(keywordId);
        }
      
        public IQueryable<NewsKeyword> GetByCreateBy(int createBy)
        {
            return _newsKeywordRepository.GetByCreateBy(createBy);
        }
      
        public IQueryable<NewsKeyword> GetByModifyBy(int modifyBy)
        {
            return _newsKeywordRepository.GetByModifyBy(modifyBy);
        }
      
        public IQueryable<NewsKeyword> GetByApplicationId(int applicationId)
        {
            return _newsKeywordRepository.GetByApplicationId(applicationId);
        }
      
        public IQueryable<NewsKeyword> GetByAccessLevelId(int accessLevelId)
        {
            return _newsKeywordRepository.GetByAccessLevelId(accessLevelId);
        }
      
        public IQueryable<NewsKeyword> GetByCreatorOrganizationId(int creatorOrganizationId)
        {
            return _newsKeywordRepository.GetByCreatorOrganizationId(creatorOrganizationId);
        }
          
    }
}      
 