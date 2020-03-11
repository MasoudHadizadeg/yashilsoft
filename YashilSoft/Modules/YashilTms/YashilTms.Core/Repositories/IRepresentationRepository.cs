			
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface IRepresentationRepository : IGenericRepository<Representation,int>
    {
        IQueryable<Representation> GetByEducationalCenterId(int educationalCenterId);
    }
}      
 