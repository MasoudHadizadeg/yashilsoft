	using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
	public class AppEntityService : GenericService<AppEntity,int>, IAppEntityService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAppEntityRepository _appEntityRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public AppEntityService (IUnitOfWork unitOfWork, IAppEntityRepository appEntityRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, appEntityRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_appEntityRepository = appEntityRepository;
			_userPrincipal = userPrincipal;
        }
			  public string GetDescription(int id)
				{
					return _appEntityRepository.GetDescription(id);
				}	
			  public string GetProps(int id)
				{
					return _appEntityRepository.GetProps(id);
				}

              public int GetIdByTitle(string editModelAppEntityTitle)
              {
                  return _appEntityRepository.GetIdByTitle(editModelAppEntityTitle);

              }
    }
}      
 