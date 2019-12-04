			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class ResourceService : GenericService<Resource,int>, IResourceService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IResourceRepository _resourceRepository;
       
		public ResourceService (IUnitOfWork unitOfWork, IResourceRepository resourceRepository) : base(unitOfWork, resourceRepository)
        {
			_unitOfWork = unitOfWork;
			_resourceRepository = resourceRepository;
        }
    }
}      
 