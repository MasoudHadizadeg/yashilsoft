			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface IRepresentationEstablishedLicenseTypeRepository : IGenericRepository<RepresentationEstablishedLicenseType,int>
    {
		          
        IQueryable<RepresentationEstablishedLicenseType> GetByCustomFilter( int? representationId, int? establishedLicenseType);
           
		
    }
}      
 