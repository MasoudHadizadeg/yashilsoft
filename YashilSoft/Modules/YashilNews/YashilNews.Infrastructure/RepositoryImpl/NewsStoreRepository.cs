using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Core.Enums;
using Yashil.Infrastructure.Data;
using YashilNews.Core.Repositories;

namespace YashilNews.Infrastructure.RepositoryImpl
{
    public class NewsStoreRepository : GenericApplicationBasedRepository<NewsStore, int>, INewsStoreRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public NewsStoreRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }


        public IQueryable<NewsStore> GetByCustomFilter(int? serviceId, int? newsType, int? language)
        {
            var query = GetAll(true);
            if (serviceId.HasValue)
            {
                query = query.Where(x => x.ServiceId == serviceId.Value);
            }

            if (newsType.HasValue)
            {
                query = query.Where(x => x.NewsType == newsType.Value);
            }
            else
            {
                query = query.Where(x => x.NewsType == (int) NewsTypeEnum.Movie || x.NewsType == (int)NewsTypeEnum.Simple || x.NewsType == (int)NewsTypeEnum.Pictorial);
            }
            if (language.HasValue)
            {
                query = query.Where(x => x.Language == language.Value);
            }


            return query;
        }
    }
}