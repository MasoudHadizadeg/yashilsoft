			using System.Linq;
            using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDms.Core.Repositories;
using YashilDms.Core.Services;

namespace YashilDms.Infrastructure.ServiceImpl
{
	public class DocumentCategoryService : GenericService<DocumentCategory,int>, IDocumentCategoryService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IDocumentCategoryRepository _documentCategoryRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public DocumentCategoryService (IUnitOfWork unitOfWork, IDocumentCategoryRepository documentCategoryRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, documentCategoryRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_documentCategoryRepository = documentCategoryRepository;
			_userPrincipal = userPrincipal;
        }

        public DocumentCategory GetDocumentDefaultCategory(int appEntityId)
        {
            return _documentCategoryRepository.GetDocumentDefaultCategory(appEntityId);
        }

        public IQueryable<DocumentCategory> GetAll(string appEntityName)
        {
            return _documentCategoryRepository.GetAll(appEntityName);
        }

        public IQueryable<DocumentCategory> GetAll(int appEntityId)
        {
            return _documentCategoryRepository.GetAll(appEntityId);
        }
    }
}      
 