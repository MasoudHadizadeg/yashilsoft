			using System.Linq;
            using System.Threading.Tasks;
            using Microsoft.EntityFrameworkCore;
            using Microsoft.EntityFrameworkCore.DynamicLinq;
            using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
	public class AdditionalUserPropRepository : GenericApplicationBasedRepository<AdditionalUserProp,int>, IAdditionalUserPropRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public AdditionalUserPropRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }

        public AdditionalUserProp GetByUserId(int userId)
        {
            return DbSet.FirstOrDefault(x => x.UserId == userId);
        }
    }
}      
