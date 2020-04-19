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
                 
        public IQueryable<NewsStore> GetByCustomFilter( int? serviceId, int? newsType, int? language)
        {
            return _newsStoreRepository.GetByCustomFilter(serviceId,newsType,language);
        }
           

    }
}      
 