using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
    public class AccessLevelService : GenericService<AccessLevel, int>, IAccessLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccessLevelRepository _accessLevelRepository;
        private readonly IUserPrincipal _userPrincipal;

        public AccessLevelService(IUnitOfWork unitOfWork, IAccessLevelRepository accessLevelRepository, IUserPrincipal userPrincipal)
            : base(unitOfWork, accessLevelRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _accessLevelRepository = accessLevelRepository;
            _userPrincipal = userPrincipal;
        }
        public string GetDescription(int id)
        {
            return _accessLevelRepository.GetDescription(id);
        }

    }
}
