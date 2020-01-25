using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilReport.Core.Repositories;

namespace YashilReport.Infrastructure.RepositoryImpl
{
    public class ReportStoreRepository : GenericRepository<ReportStore, int>, IReportStoreRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public ReportStoreRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public void DeleteContentionStrings(int reportId)
        {
            _context.ReportConnectionString.RemoveRange(
                _context.ReportConnectionString.Where(x => x.ReportId == reportId));
        }

        private Expression<Func<ReportStore, bool>> CheckReportAccess(int? reportId = null)
        {
            var userRoles = _context.UserRole.Where(x => x.UserId == _userPrincipal.Id).Select(x => x.Role);
            return x => ((reportId.HasValue && x.Id == reportId.Value) || !reportId.HasValue) &&
                        (x.CreateBy == _userPrincipal.Id ||
                         x.RoleReport.Any(c => userRoles.Contains(c.Role)) ||
                         x.UserReport.Any(u => u.UserId == _userPrincipal.Id));
        }

        public async Task<ReportStore> GetForEditAsync(int reportId, bool readOnly = true)
        {
            return await _context.ReportStore.Include(x => x.ReportConnectionString)
                .Where(CheckReportAccess()).FirstOrDefaultAsync();
        }

        public IQueryable<ReportStore> GetUserReportList()
        {
            var userRoles = _context.UserRole.Where(x => x.UserId == _userPrincipal.Id).Select(x => x.Role);
            return _context.ReportStore.Where(CheckReportAccess());
        }
    }
}