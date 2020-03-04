			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilBaseInfo.Core.Repositories;

namespace YashilBaseInfo.Infrastructure.RepositoryImpl
{
	public class AppEntityAttributeValueRepository : GenericApplicationBasedRepository<AppEntityAttributeValue,int>, IAppEntityAttributeValueRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public AppEntityAttributeValueRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
    			  public string GetValue(int id)
				{
					return DbSet.Where(x => x.Id == id).Select(x => x.Value).FirstOrDefault();
				}	
			  public string GetDescription(int id)
				{
					return DbSet.Where(x => x.Id == id).Select(x => x.Description).FirstOrDefault();
				}	
	
    }
}      
