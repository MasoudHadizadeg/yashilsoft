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
		
        public IQueryable<Service> GetByParentId(int parentId)
        {
            return _serviceRepository.GetByParentId(parentId);
        }
      
        public IQueryable<Service> GetByAppEntityId(int appEntityId)
        {
            return _serviceRepository.GetByAppEntityId(appEntityId);
        }
      
        public IQueryable<Service> GetByCreateBy(int createBy)
        {
            return _serviceRepository.GetByCreateBy(createBy);
        }
      
        public IQueryable<Service> GetByModifyBy(int modifyBy)
        {
            return _serviceRepository.GetByModifyBy(modifyBy);
        }
      
        public IQueryable<Service> GetByApplicationId(int applicationId)
        {
            return _serviceRepository.GetByApplicationId(applicationId);
        }
      
        public IQueryable<Service> GetByAccessLevelId(int accessLevelId)
        {
            return _serviceRepository.GetByAccessLevelId(accessLevelId);
        }
      
        public IQueryable<Service> GetByCreatorOrganizationId(int creatorOrganizationId)
        {
            return _serviceRepository.GetByCreatorOrganizationId(creatorOrganizationId);
        }
          
    }
}      
 