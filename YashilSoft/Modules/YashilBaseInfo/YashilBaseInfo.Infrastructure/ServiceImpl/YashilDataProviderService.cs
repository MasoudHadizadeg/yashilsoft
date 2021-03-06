using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
    public class YashilDataProviderService : GenericService<YashilDataProvider, int>, IYashilDataProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IYashilDataProviderRepository _yashilDataProviderRepository;

        public YashilDataProviderService(IUnitOfWork unitOfWork,
            IYashilDataProviderRepository yashilDataProviderRepository, IUserPrincipal userPrincipal) : base(unitOfWork,
            yashilDataProviderRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _yashilDataProviderRepository = yashilDataProviderRepository;
        }
    }
}