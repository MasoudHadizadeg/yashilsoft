			
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
       
		public DocFormatService (IUnitOfWork unitOfWork, IDocFormatRepository docFormatRepository) : base(unitOfWork, docFormatRepository)
        {
			_unitOfWork = unitOfWork;
			_docFormatRepository = docFormatRepository;
        }
    }
}      
 