			
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class ResourceAppActionRepository : GenericRepository<ResourceAppAction,int>, IResourceAppActionRepository
    {
        private readonly YashilAppDbContext _context;
		public ResourceAppActionRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
            {
                _context = context;
            }
    }
}      
