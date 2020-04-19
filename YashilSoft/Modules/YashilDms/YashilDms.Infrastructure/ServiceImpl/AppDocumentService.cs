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

        public IQueryable<AppDocument> GetObjectDocuments(string entityName, int objectId, int docCategoryId)
        {
            return _appDocumentRepository.GetObjectDocuments(entityName, objectId, docCategoryId);
        }

        public bool SaveDocument(int? docCategoryId, int appEntityId, int docTypeId, int? docId, int objectId, IFormFile file)
        {
            if (!docCategoryId.HasValue)
            {
                var documentCategory = _documentCategoryService.GetDocumentDefaultCategory(appEntityId);
                if (documentCategory == null)
                {
                    documentCategory = new DocumentCategory
                    { AppEntityId = appEntityId,  Title = @"اسناد" };
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
                    ContentType = file.ContentType
                };
                Add(appDocument, true);
            }
            else
            {
                appDocument = Get(docId);
                appDocument.Title = docType.Title;
                appDocument.OrginalName = file.FileName;
                appDocument.Extension = extension;
                appDocument.ContentType = file.ContentType;
            }

            if (docType.SaveToDisk)
            {
                var directory = Path.Combine(_physicalDocsFilePath, docTypeId.ToString());
                var filePath = Path.Combine(directory, appDocument.Id.ToString());
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using var fileStream = File.Create(filePath);

                file.CopyTo(fileStream);
                fileStream.Close();
                fileStream.Dispose();
            }
            else
            {
                using var ms = new MemoryStream();
                file.CopyTo(ms);
                appDocument.DocumentFile = ms.GetBuffer();
                ms.Close();
                ms.Dispose();
            }

            Update(appDocument, appDocument.Id, true);

            return true;
        }

        public AppDocument GetFile(int appDocumentId)
        {
            var appDocument = _appDocumentRepository.Get(appDocumentId, true);
            if (appDocument.DocType.SaveToDisk)
            {
                var directory = Path.Combine(_physicalDocsFilePath, appDocument.DocType.Id.ToString());
                var filePath = Path.Combine(directory, appDocument.Id.ToString());
                if (File.Exists(filePath))
                {
                    appDocument.DocumentFile= File.ReadAllBytes(filePath);
                }
            }
            return appDocument;
        }

        public int GetIdByTitle(string appEntityTitle)
        {
            return _appDocumentRepository.GetIdByTitle(appEntityTitle);
        }

    }
}