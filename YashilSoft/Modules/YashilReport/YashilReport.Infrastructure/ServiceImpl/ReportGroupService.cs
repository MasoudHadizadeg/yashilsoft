
using System.Linq;
using System.Threading.Tasks;
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

        public ReportGroupService(IUnitOfWork unitOfWork, IReportGroupRepository reportGroupRepository) : base(unitOfWork, reportGroupRepository)
        {
            _unitOfWork = unitOfWork;
            _reportGroupRepository = reportGroupRepository;
        }

        public  IQueryable<ReportGroup> GetByReportId(int id)
        {
           return  _reportGroupRepository.GetByReportId(id);
        }

        public IQueryable<ReportGroup> GetNotAssignedToReportId(int id)
        {
            return _reportGroupRepository.GetNotAssignedToReportId(id);
        }
    }
}
