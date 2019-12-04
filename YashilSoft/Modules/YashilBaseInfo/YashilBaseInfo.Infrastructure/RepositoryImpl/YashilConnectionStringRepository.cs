			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilBaseInfo.Core.Repositories;

namespace YashilBaseInfo.Infrastructure.RepositoryImpl
{
	public class YashilConnectionStringRepository : GenericRepository<YashilConnectionString,int>, IYashilConnectionStringRepository
    {
        private readonly YashilAppDbContext _context;
		public YashilConnectionStringRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
