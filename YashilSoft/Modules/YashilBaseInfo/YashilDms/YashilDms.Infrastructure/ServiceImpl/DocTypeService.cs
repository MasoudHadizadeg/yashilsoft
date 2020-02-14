			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDms.Core.Repositories;
using YashilDms.Core.Services;

namespace YashilDms.Infrastructure.ServiceImpl
{
	public class DocTypeService : GenericService<DocType,int>, IDocTypeService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IDocTypeRepository _docTypeRepository;
       
		public DocTypeService (IUnitOfWork unitOfWork, IDocTypeRepository docTypeRepository) : base(unitOfWork, docTypeRepository)
        {
			_unitOfWork = unitOfWork;
			_docTypeRepository = docTypeRepository;
        }
    }
}      
 