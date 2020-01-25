using Microsoft.EntityFrameworkCore;
using System.Linq;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilReport.Core.Repositories;

using Yashil.Common.Core.Classes; namespace YashilReport.Infrastructure.RepositoryImpl
{
    public class ReportGroupRepository : GenericRepository<ReportGroup, int>, IReportGroupRepository
    {
        private readonly YashilAppDbContext _context;

        public ReportGroupRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
            _context = context;
        }

        public IQueryable<ReportGroup> GetByReportId(int id)
        {
            return DbSet.AsNoTracking().Where(x => x.ReportGroupReport.Any(d => d.ReportStoreId == id));
        }

        public IQueryable<ReportGroup> GetNotAssignedToReportId(int id)
        {
            return DbSet.AsNoTracking().Where(x => x.ReportGroupReport.All(d => d.ReportStoreId != id));
        }

        public IQueryable<ReportGroup> GetUserReportGroupList(int currentUserId)
        {
            var userRoles = _context.UserRole.Where(x => x.UserId == currentUserId).Select(x => x.Role);
            var userReports = _context.ReportStore.Where(x =>
                x.CreateBy == currentUserId || x.RoleReport.Any(c => userRoles.Contains(c.Role)) ||
                x.UserReport.Any(u => u.UserId == currentUserId)).Select(x => x.Id);
            return _context.ReportGroup.Where(x => x.ReportGroupReport.Any(d => userReports.Contains(d.ReportStoreId)));
        }
    }
}