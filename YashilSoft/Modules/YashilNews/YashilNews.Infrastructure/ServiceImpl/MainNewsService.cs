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
                 
        public IQueryable<MainNews> GetByCustomFilter( int? newsStoreId)
        {
            return _mainNewsRepository.GetByCustomFilter(newsStoreId);
        }
           

    }
}      
 