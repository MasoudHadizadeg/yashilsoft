			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface ICourseService : IGenericService<Course>
    {
        string GetTopic(int id);
    }
}      
 