using System.Linq;
using Microsoft.AspNetCore.Http;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDms.Core.Services
{
    public interface IAppDocumentService : IGenericService<AppDocument>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId">کد جدول، این کد ممکن است مجازی باشد</param>
        /// <param name="objectId">کد رکورد مربوط به جدول</param>
        /// <param name="docCategoryId"></param>
        /// <returns></returns>
        IQueryable<AppDocument> GetObjectDocuments(int entityId, int objectId, int docCategoryId);

        bool SaveDocument(int? docCategoryId, int appEntityId, int docTypeId, int? docId, int objectId, IFormFile file);
        AppDocument GetFile(int appDocumentId);
    }
}