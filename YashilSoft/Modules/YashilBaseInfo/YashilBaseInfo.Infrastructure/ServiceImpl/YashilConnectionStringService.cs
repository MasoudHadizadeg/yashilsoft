			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
	public class YashilConnectionStringService : GenericService<YashilConnectionString,int>, IYashilConnectionStringService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IYashilConnectionStringRepository _yashilConnectionStringRepository;
       
		public YashilConnectionStringService (IUnitOfWork unitOfWork, IYashilConnectionStringRepository yashilConnectionStringRepository) : base(unitOfWork, yashilConnectionStringRepository)
        {
			_unitOfWork = unitOfWork;
			_yashilConnectionStringRepository = yashilConnectionStringRepository;
        }
    }
}      
 