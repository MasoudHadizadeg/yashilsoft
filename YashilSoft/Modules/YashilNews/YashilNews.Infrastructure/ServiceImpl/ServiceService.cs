	using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilNews.Core.Repositories;
using YashilNews.Core.Services;

namespace YashilNews.Infrastructure.ServiceImpl
{
	public class ServiceService : GenericService<Service,int>, IServiceService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceRepository _serviceRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public ServiceService (IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, serviceRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_serviceRepository = serviceRepository;
			_userPrincipal = userPrincipal;
        }
                 
        public IQueryable<Service> GetByCustomFilter( int? parentId, int? appEntityId)
        {
            return _serviceRepository.GetByCustomFilter(parentId,appEntityId);
        }
           

    }
}      
 