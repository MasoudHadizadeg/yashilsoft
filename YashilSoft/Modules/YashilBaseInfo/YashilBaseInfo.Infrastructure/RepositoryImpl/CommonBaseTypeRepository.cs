			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilBaseInfo.Core.Repositories;

namespace YashilBaseInfo.Infrastructure.RepositoryImpl
{
	public class CommonBaseTypeRepository : GenericApplicationBasedRepository<CommonBaseType,int>, ICommonBaseTypeRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public CommonBaseTypeRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
    			  public string GetDescription(int id)
				{
					return DbSet.Where(x => x.Id == id).Select(x => x.Description).FirstOrDefault();
				}	
	
    }
}      
