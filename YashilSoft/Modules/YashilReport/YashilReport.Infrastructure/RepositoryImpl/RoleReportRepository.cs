using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilReport.Core.Repositories;
using Yashil.Common.Core.Classes;

namespace YashilReport.Infrastructure.RepositoryImpl
{
    public class RoleReportRepository : GenericRepository<RoleReport, int>, IRoleReportRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public RoleReportRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public async Task AssignSelectedReportSoresToRole(List<int> selectedReportStores, int roleId, bool assign)
        {
            if (!assign)
            {
                DbSet.RemoveRange(DbSet.Where(x => selectedReportStores.Contains(x.ReportId) && x.RoleId == roleId));
            }
            else
            {
                foreach (var roleReport in selectedReportStores.Select(selectedReportStore => new RoleReport
                {
                    CreateBy = _userPrincipal.Id,
                    CreationDate = DateTime.Now,
                    ReportId = selectedReportStore,
                    RoleId = roleId
                }))
                {
                    await AddAsync(roleReport);
                }
            }
        }
    }
}