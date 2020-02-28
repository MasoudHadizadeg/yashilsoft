			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilDms.Core.Repositories
{
	public interface IAppDocumentRepository : IGenericRepository<AppDocument>
    {
        IQueryable<AppDocument> GetObjectDocuments(int entityId, int objectId, int docCategoryId);
    }
}      
