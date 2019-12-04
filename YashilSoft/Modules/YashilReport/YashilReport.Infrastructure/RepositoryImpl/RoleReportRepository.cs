			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilReport.Core.Repositories;

namespace YashilReport.Infrastructure.RepositoryImpl
{
	public class RoleReportRepository : GenericRepository<RoleReport,int>, IRoleReportRepository
    {
        private readonly YashilAppDbContext _context;
		public RoleReportRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
