			
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilReport.Core.Repositories;

namespace YashilReport.Infrastructure.RepositoryImpl
{
	public class ReportConnectionStringRepository : GenericRepository<ReportConnectionString,int>, IReportConnectionStringRepository
    {
        private readonly YashilAppDbContext _context;
		public ReportConnectionStringRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
            {
                _context = context;
            }
    }
}      
