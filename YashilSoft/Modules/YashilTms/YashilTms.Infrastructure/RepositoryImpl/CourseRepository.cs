			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
	public class CourseRepository : GenericApplicationBasedRepository<Course,int>, ICourseRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public CourseRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }

        public IQueryable<Course> GetByEducationalCenterId(int educationalCenterId)
        {
            return DbSet.Where(ApplicationBasedDefaultFilter()).Where(x => x.EducationalCenterId == educationalCenterId);
        }
    }
}      
