using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDms.Core.Services
{
    public interface IDocumentCategoryService : IGenericService<DocumentCategory>
    {
        DocumentCategory GetDocumentDefaultCategory(int appEntityId, int objectId);
        IQueryable<DocumentCategory> GetAll(int appEntityId, int objectId);
    }
}