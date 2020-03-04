	using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class EducationalCenterService : GenericService<EducationalCenter,int>, IEducationalCenterService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IEducationalCenterRepository _educationalCenterRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public EducationalCenterService (IUnitOfWork unitOfWork, IEducationalCenterRepository educationalCenterRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, educationalCenterRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_educationalCenterRepository = educationalCenterRepository;
			_userPrincipal = userPrincipal;
        }
			  public string GetAbout(int id)
				{
					return _educationalCenterRepository.GetAbout(id);
				}	
			  public string GetGoal(int id)
				{
					return _educationalCenterRepository.GetGoal(id);
				}	
			  public string GetDescription(int id)
				{
					return _educationalCenterRepository.GetDescription(id);
				}	
			  public string GetAbility(int id)
				{
					return _educationalCenterRepository.GetAbility(id);
				}	
	
    }
}      
 