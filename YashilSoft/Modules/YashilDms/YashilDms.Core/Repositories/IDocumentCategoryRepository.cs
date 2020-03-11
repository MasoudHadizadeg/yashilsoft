using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDms.Core.Repositories
{
    public interface IDocumentCategoryRepository : IGenericRepository<DocumentCategory, int>
    {
        DocumentCategory GetDocumentDefaultCategory(int appEntityId, int objectId);
        IQueryable<DocumentCategory> GetAll(int appEntityId, int objectId);
    }
}