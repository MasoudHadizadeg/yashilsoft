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
    public class CoursePlanningRepository : GenericApplicationBasedRepository<CoursePlanning, int>, ICoursePlanningRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public CoursePlanningRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public IQueryable<CoursePlanning> GetByRepresentationId(int representationId)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x => x.RepresentationId == representationId);
        }

        public IQueryable<CoursePlanning> GetByCourseCategoryId(int courseCategoryId, bool hierarchical)
        {
            if (hierarchical)
            {
                var courseCategory = _context.CourseCategory.Find(courseCategoryId);
                if (courseCategory != null)
                {
                    return GetAll(true)
                        .Where(x => x.Course.CourseCategory.CodePath.StartsWith(courseCategory.CodePath));
                }
            }

            return GetAll(true).Where(x => x.Course.CourseCategoryId == courseCategoryId);
        }

        public IQueryable<CoursePlanning> GetByMainCourseCategoryId(int educationalCenterMainCourseCategoryId)
        {
            return GetAll(true).Where(x => x.Course.CourseCategory.EducationalCenterMainCourseCategoryId == educationalCenterMainCourseCategoryId);
        }

        public override IQueryable<CoursePlanning> GetAll(bool readOnly = false)
        {
            var query = base.GetAll(readOnly);
            var additionalUserProp = _context.AdditionalUserProp.AsNoTracking()
                .FirstOrDefault(x => x.UserId == _userPrincipal.Id);
            if (additionalUserProp != null)
            {
                if (additionalUserProp.RepresentationId.HasValue)
                    query = query.Where(x => x.RepresentationId == additionalUserProp.RepresentationId);
                else
                    query = query.Where(x =>
                        x.Representation.EducationalCenterId == additionalUserProp.EducationalCenterId);
            }

            return query;
        }

        public override ValueTask<CoursePlanning> GetAsync(object id, bool readOnly = true)
        {
            int key = (int)id;
            var firstOrDefaultAsync = DbSet.Include(x => x.Course)
                .FirstOrDefaultAsync(x => x.Id == key);
            return new ValueTask<CoursePlanning>(firstOrDefaultAsync);
        }
    }
}