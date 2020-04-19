	using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilNews.Core.Repositories;
using YashilNews.Core.Services;

namespace YashilNews.Infrastructure.ServiceImpl
{
	public class MainNewsService : GenericService<MainNews,int>, IMainNewsService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMainNewsRepository _mainNewsRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public MainNewsService (IUnitOfWork unitOfWork, IMainNewsRepository mainNewsRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, mainNewsRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_mainNewsRepository = mainNewsRepository;
			_userPrincipal = userPrincipal;
        }
		
        public IQueryable<MainNews> GetByNewsStoreId(int newsStoreId)
        {
            return _mainNewsRepository.GetByNewsStoreId(newsStoreId);
        }
      
        public IQueryable<MainNews> GetByNewsPropertyId(int newsPropertyId)
        {
            return _mainNewsRepository.GetByNewsPropertyId(newsPropertyId);
        }
      
        public IQueryable<MainNews> GetByCreateBy(int createBy)
        {
            return _mainNewsRepository.GetByCreateBy(createBy);
        }
      
        public IQueryable<MainNews> GetByModifyBy(int modifyBy)
        {
            return _mainNewsRepository.GetByModifyBy(modifyBy);
        }
      
        public IQueryable<MainNews> GetByApplicationId(int applicationId)
        {
            return _mainNewsRepository.GetByApplicationId(applicationId);
        }
      
        public IQueryable<MainNews> GetByCreatorOrganizationId(int creatorOrganizationId)
        {
            return _mainNewsRepository.GetByCreatorOrganizationId(creatorOrganizationId);
        }
          
    }
}      
 