			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilBaseInfo.Core.Repositories;

namespace YashilBaseInfo.Infrastructure.RepositoryImpl
{
	public class AccessLevelRepository : GenericRepository<AccessLevel,int>, IAccessLevelRepository
    {
        private readonly YashilAppDbContext _context;
		public AccessLevelRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
