			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilDms.Core.Repositories
{
	public interface IDocTypeRepository : IGenericRepository<DocType, int>
    {
        IQueryable<DocType> GetEntityDocTypes(string entityName, int docCategoryId);
        IQueryable<DocType> GetEntitiesByAppEntityName(string appEntityName);
        IQueryable<DocType> GetEntitiesByDocumentCategoryId(int documentCategoryId);
    }
}      
