			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
	public class RepresentationEstablishedLicenseTypeRepository : GenericApplicationBasedRepository<RepresentationEstablishedLicenseType,int>, IRepresentationEstablishedLicenseTypeRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public RepresentationEstablishedLicenseTypeRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }
                 
   
    public IQueryable<RepresentationEstablishedLicenseType> GetByCustomFilter( int? representationId, int? establishedLicenseType)
        {
            var query= GetAll(true);
                         if ( representationId.HasValue)
                {
                    query = query.Where(x => x.RepresentationId == representationId.Value);
                }
                          if ( establishedLicenseType.HasValue)
                {
                    query = query.Where(x => x.EstablishedLicenseType == establishedLicenseType.Value);
                }
                  
          
            return query;
        }
           

       
    }
}      
