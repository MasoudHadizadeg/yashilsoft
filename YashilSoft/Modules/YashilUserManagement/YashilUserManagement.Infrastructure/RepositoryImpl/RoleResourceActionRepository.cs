			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class RoleResourceActionRepository : GenericRepository<RoleResourceAction,int>, IRoleResourceActionRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public RoleResourceActionRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
    	
    }
}      
