			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class PersonRepository : GenericApplicationBasedRepository<Person,int>, IPersonRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public PersonRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
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
