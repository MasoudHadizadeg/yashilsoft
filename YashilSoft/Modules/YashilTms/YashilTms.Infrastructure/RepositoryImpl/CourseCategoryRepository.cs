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
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x => x.EducationalCenterMainCourseCategoryId == educationalCenterMainCourseCategoryId);
        }

        public IQueryable<CourseCategory> GetRepresentationCourseCategories(int representationId)
        {
            IQueryable<CourseCategory> q1 = 
                from rc in _context.RepresentationCourseCategory.Where(x => x.RepresentationId == representationId)
                                            from childCourseCategory in _context.CourseCategory.Where(childCourseCategory => childCourseCategory.CodePath.StartsWith(rc.CourseCategory.CodePath))
                                            select childCourseCategory;
            IQueryable<CourseCategory> q2 = from rc in _context.RepresentationCourseCategory.Where(x => x.RepresentationId == representationId)
                                            from parentCourseCategory in _context.CourseCategory.Where(parentCourseCategory => rc.CourseCategory.CodePath.Contains(parentCourseCategory.CodePath))
                                            select parentCourseCategory;
            return q1.Distinct().Union(q2.Distinct());

        }

        public IQueryable<CourseCategory> GetRepresentationCourseCategories(int representationId, int courseCategoryId)
        {
            var representationCourseCategories = GetRepresentationCourseCategories(representationId);
            var courseCategory = _context.CourseCategory.Find(courseCategoryId);
            if (courseCategory != null)
            {
                return representationCourseCategories.Where(x => x.CodePath.StartsWith(courseCategory.CodePath));
            }

            return null;
        }

        public override ValueTask<CourseCategory> GetAsync(object id, bool readOnly = true)
        {
            int key = (int)id;
            var firstOrDefaultAsync = DbSet.Include(x => x.EducationalCenterMainCourseCategory)
                .FirstOrDefaultAsync(x => x.Id == key);
            return new ValueTask<CourseCategory>(firstOrDefaultAsync);
        }
    }
}