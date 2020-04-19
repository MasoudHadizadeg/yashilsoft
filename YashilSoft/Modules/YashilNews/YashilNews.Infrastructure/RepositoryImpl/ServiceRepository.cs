			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilNews.Core.Repositories;

namespace YashilNews.Infrastructure.RepositoryImpl
{
	public class ServiceRepository : GenericApplicationBasedRepository<Service,int>, IServiceRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public ServiceRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
                 
   
    public IQueryable<Service> GetByCustomFilter( int? parentId, int? appEntityId)
        {
            var query= GetAll(true);
                         if ( parentId.HasValue)
                {
                    query = query.Where(x => x.ParentId == parentId.Value);
                }
                          if ( appEntityId.HasValue)
                {
                    query = query.Where(x => x.AppEntityId == appEntityId.Value);
                }
                  
          
            return query;
        }
           

       
    }
}      
