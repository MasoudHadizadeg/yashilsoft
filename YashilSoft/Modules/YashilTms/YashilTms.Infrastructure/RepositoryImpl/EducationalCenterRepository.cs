			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
	public class EducationalCenterRepository : GenericApplicationBasedRepository<EducationalCenter,int>, IEducationalCenterRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public EducationalCenterRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
    			  public string GetAbout(int id)
				{
					return DbSet.Where(x => x.Id == id).Select(x => x.About).FirstOrDefault();
				}	
			  public string GetGoal(int id)
				{
					return DbSet.Where(x => x.Id == id).Select(x => x.Goal).FirstOrDefault();
				}	
			  public string GetDescription(int id)
				{
					return DbSet.Where(x => x.Id == id).Select(x => x.Description).FirstOrDefault();
				}	
			  public string GetAbility(int id)
				{
					return DbSet.Where(x => x.Id == id).Select(x => x.Ability).FirstOrDefault();
				}	
	
    }
}      
