
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
    public interface ICourseService : IGenericService<Course, int>
    {
        IQueryable<Course> GetByEducationalCenterId(int educationalCenterId);
    }
}
