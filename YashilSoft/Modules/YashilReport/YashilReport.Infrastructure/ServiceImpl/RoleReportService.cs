using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;

namespace YashilReport.Infrastructure.ServiceImpl
{
    public class RoleReportService : GenericService<RoleReport, int>, IRoleReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleReportRepository _roleReportRepository;

        public RoleReportService(IUnitOfWork unitOfWork, IRoleReportRepository roleReportRepository, YashilAppDbContext context, IUserPrincipal userPrincipal) : base(unitOfWork, roleReportRepository,
            userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _roleReportRepository = roleReportRepository;
        }
    }
}