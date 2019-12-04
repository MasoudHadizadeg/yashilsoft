			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilReport.Core.Repositories;

namespace YashilReport.Infrastructure.RepositoryImpl
{
	public class UserReportRepository : GenericRepository<UserReport,int>, IUserReportRepository
    {
        private readonly YashilAppDbContext _context;
		public UserReportRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
