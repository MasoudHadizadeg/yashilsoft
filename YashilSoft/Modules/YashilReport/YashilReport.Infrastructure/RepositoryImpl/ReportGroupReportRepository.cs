			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilReport.Core.Repositories;

namespace YashilReport.Infrastructure.RepositoryImpl
{
	public class ReportGroupReportRepository : GenericRepository<ReportGroupReport,int>, IReportGroupReportRepository
    {
        private readonly YashilAppDbContext _context;
		public ReportGroupReportRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
