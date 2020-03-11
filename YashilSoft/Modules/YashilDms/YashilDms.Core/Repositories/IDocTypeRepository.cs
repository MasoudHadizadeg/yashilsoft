			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilDms.Core.Repositories
{
	public interface IDocTypeRepository : IGenericRepository<DocType, int>
    {
        IQueryable<DocType> GetEntityDocTypes(int entityId);
    }
}      
