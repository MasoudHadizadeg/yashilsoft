			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDms.Core.Repositories;
using YashilDms.Core.Services;

namespace YashilDms.Infrastructure.ServiceImpl
{
	public class AppDocumentService : GenericService<AppDocument,int>, IAppDocumentService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAppDocumentRepository _appDocumentRepository;
       
		public AppDocumentService (IUnitOfWork unitOfWork, IAppDocumentRepository appDocumentRepository) : base(unitOfWork, appDocumentRepository)
        {
			_unitOfWork = unitOfWork;
			_appDocumentRepository = appDocumentRepository;
        }
    }
}      
 