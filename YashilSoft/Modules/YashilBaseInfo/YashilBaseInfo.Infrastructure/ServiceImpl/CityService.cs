			using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
	public class CityService : GenericService<City,int>, ICityService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICityRepository _cityRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public CityService (IUnitOfWork unitOfWork, ICityRepository cityRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, cityRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_cityRepository = cityRepository;
			_userPrincipal = userPrincipal;
        }
    }
}      
 