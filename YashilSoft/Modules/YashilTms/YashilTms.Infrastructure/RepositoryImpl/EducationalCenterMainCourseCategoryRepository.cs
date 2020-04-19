using System;
using System.Collections.Generic;
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
    public class EducationalCenterMainCourseCategoryRepository :
        GenericApplicationBasedRepository<EducationalCenterMainCourseCategory, int>,
        IEducationalCenterMainCourseCategoryRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public EducationalCenterMainCourseCategoryRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) :
            base(context, userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public async Task AssignSelectedItemsToEducationalCenter(List<int> mainCourseCategories,
            int educationalCenterId, bool assign)
        {
            if (!assign)
            {
                DbSet.RemoveRange(DbSet.Where(x => mainCourseCategories.Contains(x.Id)));
            }
            else
            {
                foreach (var educationalCenterMainCourseCategory in mainCourseCategories.Select(mainCourseCategoryId =>
                    new EducationalCenterMainCourseCategory
                    {
                        CreateBy = _userPrincipal.Id,
                        CreationDate = DateTime.Now,
                        EducationalCenterId = educationalCenterId,
                        MainCourseCategoryId = mainCourseCategoryId
                    }))
                {
                    await AddAsync(educationalCenterMainCourseCategory);
                }
            }
        }

        public IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoryByRepresentationId(int representationId)
        {
            var representation = _context.Representation.FirstOrDefault(x => x.Id == representationId);
            if (representation != null)
            {
                return GetMainCourseCategoriesByEducationalCenterId(representation.EducationalCenterId);
            }

            return null;
        }

        public IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoriesByCourseCategoryId(int courseCategoryId, in bool hierarchical = true)
        {
            var query = DbSet.Include(x => x.MainCourseCategory).Include(x => x.CourseCategory)
                .Where(ApplicationBasedDefaultFilter());
            query = query.Where(x => x.CourseCategory.Any(c => c.CodePath.StartsWith("," + courseCategoryId)));
            return query;
        }

        public IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoriesByEducationalCenterId(int? id)
        {
            var query = DbSet.Include(x => x.MainCourseCategory).Include(x => x.CourseCategory)
                .Where(ApplicationBasedDefaultFilter());
            if (id.HasValue)
            {
                return query.Where(x => x.EducationalCenterId == id);
            }

            var additionalUserProp = _context.AdditionalUserProp.AsNoTracking().FirstOrDefault(x => x.UserId == _userPrincipal.Id);
            if (additionalUserProp != null)
            {
                return query.Where(x => x.EducationalCenterId == additionalUserProp.EducationalCenterId);
            }
            return query;
        }

        public override IQueryable<EducationalCenterMainCourseCategory> GetAll(bool readOnly = false)
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
        public IQueryable<EducationalCenterMainCourseCategory> GetByCustomFilter(int? educationalCenterId, int? mainCourseCategoryId)
        {
            var query = GetAll(true);
            if (educationalCenterId.HasValue)
            {
                query = query.Where(x => x.EducationalCenterId == educationalCenterId.Value);
            }
            if (mainCourseCategoryId.HasValue)
            {
                query = query.Where(x => x.MainCourseCategoryId == mainCourseCategoryId.Value);
            }


            return query;
        }
    }
}