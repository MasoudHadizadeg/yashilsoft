			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
	public class CoursesPlanningStudentRepository : GenericApplicationBasedRepository<CoursesPlanningStudent,int>, ICoursesPlanningStudentRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public CoursesPlanningStudentRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
    }
}      
