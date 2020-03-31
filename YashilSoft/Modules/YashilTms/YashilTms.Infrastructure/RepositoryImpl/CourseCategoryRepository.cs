using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
    public class CourseCategoryRepository : GenericApplicationBasedRepository<CourseCategory, int>,
        ICourseCategoryRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public CourseCategoryRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public override IQueryable<CourseCategory> GetAll(bool readOnly = false)
        {
            var additionalUserProp = _context.AdditionalUserProp.AsNoTracking()
                .FirstOrDefault(x => x.UserId == _userPrincipal.Id);
            if (additionalUserProp != null)
            {
                return base.GetAll(readOnly).Where(x =>
                    x.EducationalCenterMainCourseCategory.EducationalCenterId ==
                    additionalUserProp.EducationalCenterId);
            }

            return base.GetAll(readOnly);
        }

        public IQueryable<CourseCategory> GetByEducationalCenterId(int educationalCenterId)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x =>
                x.EducationalCenterMainCourseCategory.EducationalCenterId == educationalCenterId);
        }

        public IQueryable<CourseCategory> GetByEducationalCenterMainCourseCategoryId(
            int educationalCenterMainCourseCategoryId)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x =>
                x.EducationalCenterMainCourseCategoryId == educationalCenterMainCourseCategoryId);
        }

        public override ValueTask<CourseCategory> GetAsync(object id, bool readOnly = true)
        {
            int key = (int) id;
            var firstOrDefaultAsync = DbSet.Include(x => x.EducationalCenterMainCourseCategory)
                .FirstOrDefaultAsync(x => x.Id == key);
            return new ValueTask<CourseCategory>(firstOrDefaultAsync);
        }
    }
}