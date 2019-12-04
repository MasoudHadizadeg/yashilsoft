			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class AppActionRepository : GenericRepository<AppAction,int>, IAppActionRepository
    {
        private readonly YashilAppDbContext _context;
		public AppActionRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
