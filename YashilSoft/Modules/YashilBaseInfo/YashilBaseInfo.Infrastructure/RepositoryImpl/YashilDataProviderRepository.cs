			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilBaseInfo.Core.Repositories;

namespace YashilBaseInfo.Infrastructure.RepositoryImpl
{
	public class YashilDataProviderRepository : GenericRepository<YashilDataProvider,int>, IYashilDataProviderRepository
    {
        private readonly YashilAppDbContext _context;
		public YashilDataProviderRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
