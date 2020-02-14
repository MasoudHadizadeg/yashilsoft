			using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDms.Core.Repositories;
using YashilDms.Core.Services;

namespace YashilDms.Infrastructure.ServiceImpl
{
	public class DocFormatService : GenericService<DocFormat,int>, IDocFormatService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IDocFormatRepository _docFormatRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public DocFormatService (IUnitOfWork unitOfWork, IDocFormatRepository docFormatRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, docFormatRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_docFormatRepository = docFormatRepository;
			_userPrincipal = userPrincipal;
        }
    }
}      
 