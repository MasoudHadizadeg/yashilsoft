			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilDms.Core.Repositories
{
	public interface IAppDocumentRepository : IGenericRepository<AppDocument, int>
    {
        IQueryable<AppDocument> GetObjectDocuments(string entityName, int objectId, int docCategoryId);
        int GetIdByTitle(string appEntityTitle);
    }
}      
