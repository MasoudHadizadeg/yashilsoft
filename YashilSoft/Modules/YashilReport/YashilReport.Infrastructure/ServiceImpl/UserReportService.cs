using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;

namespace YashilReport.Infrastructure.ServiceImpl
{
    public class UserReportService : GenericService<UserReport, int>, IUserReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserReportRepository _userReportRepository;

        public UserReportService(IUnitOfWork unitOfWork, IUserReportRepository userReportRepository,
            IUserPrincipal userPrincipal) : base(unitOfWork, userReportRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _userReportRepository = userReportRepository;
        }
    }
}