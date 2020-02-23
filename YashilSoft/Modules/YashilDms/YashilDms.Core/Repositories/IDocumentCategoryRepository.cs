using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDms.Core.Repositories
{
    public interface IDocumentCategoryRepository : IGenericRepository<DocumentCategory>
    {
        DocumentCategory GetDocumentDefaultCategory(int appEntityId, int objectId);
    }
}