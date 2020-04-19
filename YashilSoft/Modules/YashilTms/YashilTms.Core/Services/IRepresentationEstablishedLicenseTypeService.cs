
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface IRepresentationEstablishedLicenseTypeService : IGenericService<RepresentationEstablishedLicenseType,int>
    {
                 
        IQueryable<RepresentationEstablishedLicenseType> GetByCustomFilter( int? representationId, int? establishedLicenseType);
           
		
    }
}      
 