			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilReport.Core.Repositories;

using Yashil.Common.Core.Classes; namespace YashilReport.Infrastructure.RepositoryImpl
{
	public class UserReportRepository : GenericRepository<UserReport,int>, IUserReportRepository
    {
        private readonly YashilAppDbContext _context;
		public UserReportRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
            {
                _context = context;
            }
    }
}      
