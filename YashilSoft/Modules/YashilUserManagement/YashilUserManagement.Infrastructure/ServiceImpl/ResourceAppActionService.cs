			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class ResourceAppActionService : GenericService<ResourceAppAction,int>, IResourceAppActionService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IResourceAppActionRepository _resourceAppActionRepository;
       
		public ResourceAppActionService (IUnitOfWork unitOfWork, IResourceAppActionRepository resourceAppActionRepository) : base(unitOfWork, resourceAppActionRepository)
        {
			_unitOfWork = unitOfWork;
			_resourceAppActionRepository = resourceAppActionRepository;
        }
    }
}      
 