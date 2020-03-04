			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface IEducationalCenterService : IGenericService<EducationalCenter>
    {
			string GetAbout(int id);		
			string GetGoal(int id);		
			string GetDescription(int id);		
			string GetAbility(int id);		
	
    }
}      
 