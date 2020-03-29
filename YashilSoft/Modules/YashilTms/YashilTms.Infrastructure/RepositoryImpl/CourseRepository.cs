using System.Linq;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
    public class CourseRepository : GenericApplicationBasedRepository<Course, int>, ICourseRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public CourseRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public override IQueryable<Course> GetAll(bool readOnly = false)
        {
            var additionalUserProp = _context.AdditionalUserProp.AsNoTracking()
                .FirstOrDefault(x => x.UserId == _userPrincipal.Id);
            if (additionalUserProp != null)
            {
                return base.GetAll(readOnly)
                    .Where(x => x.EducationalCenterId == additionalUserProp.EducationalCenterId);
            }

            return base.GetAll(readOnly);
        }

        public IQueryable<Course> GetByEducationalCenterId(int educationalCenterId)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter())
                .Where(x => x.EducationalCenterId == educationalCenterId);
        }

        public IQueryable<Course> GetByRepresentationId(int representationId)
        {
            return GetAll(true).Where(x => x.EducationalCenter.Representation.Any(k => k.Id == representationId));
        }

        public IQueryable<Course> GetByCourseCategoryId(int courseCategoryId, bool hierarchical = true)
        {
            if (hierarchical)
            {
                var courseCategory = _context.CourseCategory.Find(courseCategoryId);
                if (courseCategory != null)
                {
                    return GetAll(true)
                        .Where(x => x.CourseCategory.CodePath.StartsWith(courseCategory.CodePath));
                }
            }

            return GetAll(true).Where(x => x.CourseCategoryId == courseCategoryId);
        }

        public IQueryable<Course> GetByMainCourseCategoryId(int educationalCenterMainCourseCategoryId)
        {
            return GetAll(true).Where(x => x.CourseCategory.EducationalCenterMainCourseCategoryId == educationalCenterMainCourseCategoryId);
        }
    }
}