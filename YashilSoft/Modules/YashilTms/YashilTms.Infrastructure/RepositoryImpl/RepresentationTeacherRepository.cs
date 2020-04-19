			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
	public class RepresentationTeacherRepository : GenericApplicationBasedRepository<RepresentationTeacher,int>, IRepresentationTeacherRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public RepresentationTeacherRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
                 
   
    public IQueryable<RepresentationTeacher> GetByCustomFilter( int? personId)
        {
            var query= GetAll(true);
                         if ( personId.HasValue)
                {
                    query = query.Where(x => x.PersonId == personId.Value);
                }
                  
          
            return query;
        }
           

       
    }
}      
