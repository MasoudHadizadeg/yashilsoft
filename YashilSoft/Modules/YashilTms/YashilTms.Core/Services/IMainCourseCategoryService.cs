
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
    public interface IMainCourseCategoryService : IGenericService<MainCourseCategory, int>
    {
        IQueryable<MainCourseCategory> GetMainCourseCategoryNotAssignedToEducationalCenterAsync(int id);
        IQueryable<MainCourseCategory> GetMainCourseCategoryAssignedToEducationalCenterAsync(int id);
        IQueryable<MainCourseCategory> GetByEducationalCenterId(int id);
    }
}
