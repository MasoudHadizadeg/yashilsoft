			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilReport.Core.Repositories;

namespace YashilReport.Infrastructure.RepositoryImpl
{
	public class ReportStoreRepository : GenericRepository<ReportStore,int>, IReportStoreRepository
    {
        private readonly YashilAppDbContext _context;
		public ReportStoreRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
