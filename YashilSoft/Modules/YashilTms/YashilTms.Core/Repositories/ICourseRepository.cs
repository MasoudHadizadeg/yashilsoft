			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface ICourseRepository : IGenericRepository<Course>
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
 