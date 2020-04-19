			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDms.Core.Services
{
	public interface IDocTypeService : IGenericService<DocType, int>
    {
        IQueryable<DocType> GetEntityDocTypes(string entityId, int docCategoryId);
        IQueryable<DocType> GetEntitiesByAppEntityName(string appEntityName);
        IQueryable<DocType> GetEntitiesByDocumentCategoryId(int documentCategoryId);
    }
}      
 