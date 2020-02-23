using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDms.Core.Repositories;
using YashilDms.Core.Services;

namespace YashilDms.Infrastructure.ServiceImpl
{
    public class AppDocumentService : GenericService<AppDocument, int>, IAppDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppDocumentRepository _appDocumentRepository;
        private readonly IUserPrincipal _userPrincipal;
        private readonly IDocTypeService _docTypeService;
        private readonly IConfiguration _configuration;
        private readonly string _physicalDocsFilePath;
        private readonly IDocumentCategoryService _documentCategoryService;

        public AppDocumentService(IUnitOfWork unitOfWork, IAppDocumentRepository appDocumentRepository,
            IUserPrincipal userPrincipal, IDocTypeService docTypeService, IConfiguration configuration,
            IDocumentCategoryService documentCategoryService)
            : base(unitOfWork, appDocumentRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _appDocumentRepository = appDocumentRepository;
            _userPrincipal = userPrincipal;
            _docTypeService = docTypeService;
            _configuration = configuration;
            _documentCategoryService = documentCategoryService;
            _physicalDocsFilePath = _configuration.GetSection("PhysicalDocsFilePath:Path").Get<string>();
            if (string.IsNullOrWhiteSpace(_physicalDocsFilePath))
            {
                throw new Exception("Physical Docs File Path Not Set In AppSetting.json");
            }
        }

        public IQueryable<AppDocument> GetObjectDocuments(int entityId, int objectId)
        {
            return _appDocumentRepository.GetObjectDocuments(entityId, objectId);
        }

        public bool SaveDocument(int? docCategoryId, int appEntityId, int docTypeId, int? docId, int objectId,
            IFormFile file)
        {
            if (!docCategoryId.HasValue)
            {
                var documentCategory = _documentCategoryService.GetDocumentDefaultCategory(appEntityId, objectId);
                if (documentCategory == null)
                {
                    documentCategory = new DocumentCategory
                    { AppEntityId = appEntityId, ObjectId = objectId, Title = @"اسناد" };
                    _documentCategoryService.Add(documentCategory, true);
                }

                docCategoryId = documentCategory.Id;
            }

            var docType = _docTypeService.Get(docTypeId, true);
            AppDocument appDocument = null;
            var extension = Path.GetExtension(file.FileName).Replace(".", "");
            if (!docId.HasValue)
            {
                appDocument = new AppDocument
                {
                    ObjectId = objectId,
                    DocTypeId = docType.Id,
                    Title = docType.Title,
                    OrginalName = file.FileName,
                    Extension = extension,
                    DocumentCategoryId = docCategoryId.Value
                };
                Add(appDocument, true);
            }
            else
            {
                appDocument = Get(docId);
                appDocument.Title = docType.Title;
                appDocument.OrginalName = file.FileName;
                appDocument.Extension = extension;
                appDocument.DocumentCategoryId = docCategoryId.Value;
            }

            if (docType.SaveToDisk)
            {
                using var fileStream =
                    File.Create(Path.Combine(_physicalDocsFilePath, docTypeId.ToString(), appDocument.Id.ToString()));
                file.CopyTo(fileStream);
                fileStream.Close();
                fileStream.Dispose();
            }
            else
            {
                using var ms = new MemoryStream();
                file.CopyTo(ms);
                appDocument.DocumentFile = ms.ToArray();
                ms.Close();
                ms.Dispose();
            }

            Update(appDocument, appDocument.Id, true);

            return true;
        }
    }
}