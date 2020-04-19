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
                 
        public IQueryable<NewsKeyword> GetByCustomFilter( int? newsStoreId, int? keywordId)
        {
            return _newsKeywordRepository.GetByCustomFilter(newsStoreId,keywordId);
        }
           

    }
}      
 