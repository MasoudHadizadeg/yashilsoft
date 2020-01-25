using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;

namespace YashilReport.Infrastructure.ServiceImpl
{
    public class ReportConnectionStringService : GenericService<ReportConnectionString, int>,
        IReportConnectionStringService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReportConnectionStringRepository _reportConnectionStringRepository;

        public ReportConnectionStringService(IUnitOfWork unitOfWork,
            IReportConnectionStringRepository reportConnectionStringRepository, IUserPrincipal userPrincipal) : base(
            unitOfWork, reportConnectionStringRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _reportConnectionStringRepository = reportConnectionStringRepository;
        }
    }
}