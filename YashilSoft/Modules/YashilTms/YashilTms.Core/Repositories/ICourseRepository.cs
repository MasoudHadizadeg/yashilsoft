			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface ICourseRepository : IGenericRepository<Course>
    {
        string GetTopic(int id);
    }
}      
