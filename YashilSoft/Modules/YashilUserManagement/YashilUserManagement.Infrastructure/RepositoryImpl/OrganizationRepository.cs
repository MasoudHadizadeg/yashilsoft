			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class OrganizationRepository : GenericApplicationBasedRepository<Organization,int>, IOrganizationRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public OrganizationRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
    			  public string GetDescription(int id)
				{
					return DbSet.Where(x => x.Id == id).Select(x => x.Description).FirstOrDefault();
				}	
			  public string GetCodePath(int id)
				{
					return DbSet.Where(x => x.Id == id).Select(x => x.CodePath).FirstOrDefault();
				}	
	
    }
}      
