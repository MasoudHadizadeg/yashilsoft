using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
    public class MainCourseCategoryRepository : GenericApplicationBasedRepository<MainCourseCategory, int>, IMainCourseCategoryRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
        public MainCourseCategoryRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public IQueryable<MainCourseCategory> GetMainCourseCategoryNotAssignedToEducationalCenterAsync(int id)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x => x.EducationalCenterMainCourseCategory.All(e => e.EducationalCenterId != id));
        }
        public IQueryable<MainCourseCategory> GetMainCourseCategoryAssignedToEducationalCenterAsync(int id)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x =>
                x.EducationalCenterMainCourseCategory.Any(e => e.EducationalCenterId == id));
        }

        public IQueryable<MainCourseCategory> GetByEducationalCenterId(int id)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x =>
                x.EducationalCenterMainCourseCategory.Any(c => c.EducationalCenterId == id));
        }
    }
}
