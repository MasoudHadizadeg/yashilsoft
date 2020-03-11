using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
    public class CourseCategoryRepository : GenericApplicationBasedRepository<CourseCategory, int>, ICourseCategoryRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
        public CourseCategoryRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public IQueryable<CourseCategory> GetByEducationalCenterId(int educationalCenterId)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x => x.EducationalCenterId == educationalCenterId);
        }
    }
}
