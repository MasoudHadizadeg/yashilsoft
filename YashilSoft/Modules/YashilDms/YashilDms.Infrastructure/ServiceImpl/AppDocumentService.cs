			using Yashil.Common.Core.Classes;
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
		private readonly IUserPrincipal _userPrincipal;
       
		public AppDocumentService (IUnitOfWork unitOfWork, IAppDocumentRepository appDocumentRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, appDocumentRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_appDocumentRepository = appDocumentRepository;
			_userPrincipal = userPrincipal;
        }
    }
}      
 