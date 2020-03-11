using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDms.Core.Services
{
    public interface IDocumentCategoryService : IGenericService<DocumentCategory, int>
    {
        DocumentCategory GetDocumentDefaultCategory(int appEntityId, int objectId);
        IQueryable<DocumentCategory> GetAll(int appEntityId, int objectId);
    }
}