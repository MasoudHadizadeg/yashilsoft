	using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilNews.Core.Repositories;
using YashilNews.Core.Services;

namespace YashilNews.Infrastructure.ServiceImpl
{
	public class NewsStoreService : GenericService<NewsStore,int>, INewsStoreService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly INewsStoreRepository _newsStoreRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public NewsStoreService (IUnitOfWork unitOfWork, INewsStoreRepository newsStoreRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, newsStoreRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_newsStoreRepository = newsStoreRepository;
			_userPrincipal = userPrincipal;
        }
		
        public IQueryable<NewsStore> GetByServiceId(int serviceId)
        {
            return _newsStoreRepository.GetByServiceId(serviceId);
        }
      
        public IQueryable<NewsStore> GetByNewsType(int newsType)
        {
            return _newsStoreRepository.GetByNewsType(newsType);
        }
      
        public IQueryable<NewsStore> GetByLanguage(int language)
        {
            return _newsStoreRepository.GetByLanguage(language);
        }
      
        public IQueryable<NewsStore> GetByCreateBy(int createBy)
        {
            return _newsStoreRepository.GetByCreateBy(createBy);
        }
      
        public IQueryable<NewsStore> GetByModifyBy(int modifyBy)
        {
            return _newsStoreRepository.GetByModifyBy(modifyBy);
        }
      
        public IQueryable<NewsStore> GetByApplicationId(int applicationId)
        {
            return _newsStoreRepository.GetByApplicationId(applicationId);
        }
      
        public IQueryable<NewsStore> GetByAccessLevelId(int accessLevelId)
        {
            return _newsStoreRepository.GetByAccessLevelId(accessLevelId);
        }
      
        public IQueryable<NewsStore> GetByCreatorOrganizationId(int creatorOrganizationId)
        {
            return _newsStoreRepository.GetByCreatorOrganizationId(creatorOrganizationId);
        }

        public IQueryable<NewsStore> GetByCustomFilter(int? serviceId, int? newsType, int? language)
        {
            return _newsStoreRepository.GetByCustomFilter(serviceId,newsType,language);
        }
    }
}      
 