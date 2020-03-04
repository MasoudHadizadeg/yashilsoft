			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface ICourseService : IGenericService<Course>
    {
			string GetDescription(int id);		
			string GetTopic(int id);		
			string GetPrerequisite(int id);		
			string GetTarget(int id);		
			string GetRequirements(int id);		
			string GetSkill(int id);		
			string GetAudience(int id);		
	
    }
}      
 