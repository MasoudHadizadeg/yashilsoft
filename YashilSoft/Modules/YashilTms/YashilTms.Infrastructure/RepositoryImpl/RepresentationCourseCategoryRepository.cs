			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
	public class RepresentationCourseCategoryRepository : GenericApplicationBasedRepository<RepresentationCourseCategory,int>, IRepresentationCourseCategoryRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public RepresentationCourseCategoryRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
                 
   
    public IQueryable<RepresentationCourseCategory> GetByCustomFilter( int? representationId, int? courseCategoryId)
        {
            var query= GetAll(true);
                         if ( representationId.HasValue)
                {
                    query = query.Where(x => x.RepresentationId == representationId.Value);
                }
                          if ( courseCategoryId.HasValue)
                {
                    query = query.Where(x => x.CourseCategoryId == courseCategoryId.Value);
                }
                  
          
            return query;
        }
           

       
    }
}      
