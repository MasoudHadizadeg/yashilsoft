			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilReport.Core.Repositories;

namespace YashilReport.Infrastructure.RepositoryImpl
{
	public class ReportGroupRepository : GenericRepository<ReportGroup,int>, IReportGroupRepository
    {
        private readonly YashilAppDbContext _context;
		public ReportGroupRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
