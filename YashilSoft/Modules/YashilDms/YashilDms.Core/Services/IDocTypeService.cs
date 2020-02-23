			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDms.Core.Services
{
	public interface IDocTypeService : IGenericService<DocType>
    {
        IQueryable<DocType> GetEntityDocTypes(int entityId);
    }
}      
 