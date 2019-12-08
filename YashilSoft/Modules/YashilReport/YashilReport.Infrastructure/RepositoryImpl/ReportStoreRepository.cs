using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilReport.Core.Repositories;

namespace YashilReport.Infrastructure.RepositoryImpl
{
    public class ReportStoreRepository : GenericRepository<ReportStore, int>, IReportStoreRepository
    {
        private readonly YashilAppDbContext _context;

        public ReportStoreRepository(YashilAppDbContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteContentionString(int reportId)
        {
            _context.ReportConnectionString.RemoveRange(
                _context.ReportConnectionString.Where(x => x.ReportId == reportId));
        }

        public async Task<ReportStore> GetForEditAsync(int reportId, bool readOnly = true)
        {
            return await _context.ReportStore.Include(x => x.ReportConnectionString).FirstOrDefaultAsync(x => x.Id == reportId);
        }
    }
}