			using System.Linq;
            using Yashil.Common.Core.Classes;
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
		private readonly IUserPrincipal _userPrincipal;
       
		public DocTypeService (IUnitOfWork unitOfWork, IDocTypeRepository docTypeRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, docTypeRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_docTypeRepository = docTypeRepository;
			_userPrincipal = userPrincipal;
        }

        public IQueryable<DocType> GetEntityDocTypes(int entityId)
        {
            return _docTypeRepository.GetEntityDocTypes(entityId);
        }
    }
}      
 