			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilNews.Core.Repositories;

namespace YashilNews.Infrastructure.RepositoryImpl
{
	public class NewsKeywordRepository : GenericApplicationBasedRepository<NewsKeyword,int>, INewsKeywordRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public NewsKeywordRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
                 
   
    public IQueryable<NewsKeyword> GetByCustomFilter( int? newsStoreId, int? keywordId)
        {
            var query= GetAll(true);
                         if ( newsStoreId.HasValue)
                {
                    query = query.Where(x => x.NewsStoreId == newsStoreId.Value);
                }
                          if ( keywordId.HasValue)
                {
                    query = query.Where(x => x.KeywordId == keywordId.Value);
                }
                  
          
            return query;
        }
           

       
    }
}      
