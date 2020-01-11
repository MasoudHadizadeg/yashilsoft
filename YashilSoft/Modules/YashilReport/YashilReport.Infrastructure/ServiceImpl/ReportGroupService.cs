using System.Linq;
using System.Security.Claims;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;

namespace YashilReport.Infrastructure.ServiceImpl
{
    public class ReportGroupService : GenericService<ReportGroup, int>, IReportGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReportGroupRepository _reportGroupRepository;
        private readonly ClaimsPrincipal _claimsPrincipal;
        public ReportGroupService(IUnitOfWork unitOfWork, IReportGroupRepository reportGroupRepository, ClaimsPrincipal claimsPrincipal) : base(unitOfWork, reportGroupRepository)
        {
            _unitOfWork = unitOfWork;
            _reportGroupRepository = reportGroupRepository;
            _claimsPrincipal = claimsPrincipal;
        }

        public  IQueryable<ReportGroup> GetByReportId(int id)
        {
           return  _reportGroupRepository.GetByReportId(id);
        }

        public IQueryable<ReportGroup> GetNotAssignedToReportId(int id)
        {
            return _reportGroupRepository.GetNotAssignedToReportId(id);
        }

        public IQueryable<ReportGroup> GetReportGroupList()
        {
            return  _reportGroupRepository.GetAll(true);
        }
    }
}
