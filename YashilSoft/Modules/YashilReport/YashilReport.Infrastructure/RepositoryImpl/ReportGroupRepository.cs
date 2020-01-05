
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
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

        public IQueryable<ReportGroup> GetByReportId(int id)
        {
            return DbSet.AsNoTracking().Where(x => x.ReportGroupReport.Any(d => d.ReportStoreId == id));
        }

        public IQueryable<ReportGroup> GetNotAssignedToReportId(int id)
        {
            return DbSet.AsNoTracking().Where(x => !x.ReportGroupReport.Any(d => d.ReportStoreId == id));
        }
    }
}      
