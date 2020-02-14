			
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilReport.Core.Repositories;

using Yashil.Common.Core.Classes; namespace YashilReport.Infrastructure.RepositoryImpl
{
	public class ReportGroupReportRepository : GenericRepository<ReportGroupReport,int>, IReportGroupReportRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public ReportGroupReportRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }
        public async Task AssignSelectedItemsToReportGroup(List<int> selectedReportStores, int groupId, bool assign)
        {

            if (!assign)
            {
                DbSet.RemoveRange(DbSet.Where(x => selectedReportStores.Contains(x.ReportStoreId) && x.ReportGroupId == groupId));
            }
            else
            {
                foreach (var reportGroupReport in selectedReportStores.Select(selectedReportStore => new ReportGroupReport
                {
                    CreateBy = _userPrincipal.Id,
                    CreationDate = DateTime.Now,
                    ReportStoreId = selectedReportStore,
                    ReportGroupId = groupId
                }))
                {
                    await AddAsync(reportGroupReport);
                }
            }
        }
    }
}      
