using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDms.Core.Services;
using YashilDms.Web.Areas.Dms.ViewModels;

namespace YashilDms.Web.Areas.Dms.Controllers
{
    public class AppDocumentController : BaseController<AppDocument, int, AppDocumentListViewModel, AppDocumentEditModel
        , AppDocumentSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppDocumentService _appDocumentService;
        private readonly IDocTypeService _docTypeService;

        public AppDocumentController(IAppDocumentService appDocumentService, IMapper mapper,
            IDocTypeService docTypeService) : base(appDocumentService, mapper)
        {
            _mapper = mapper;
            _docTypeService = docTypeService;
            _appDocumentService = appDocumentService;
        }

        /// <summary>
        /// اسناد مربوط به یک رکورد از یک جدول واقعی یا مجازی را بر می گرداند
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="objectId"></param>
        /// <param name="docCategoryId"></param>
        /// <returns></returns>
        [HttpGet("GetObjectDocuments")]
        public DocumentUploadViewModel GetObjectDocuments(string entityName, int objectId,int docCategoryId)
        {
            var documentUploadViewModel = new DocumentUploadViewModel();
            var docTypes = _docTypeService.GetEntityDocTypes(entityName, docCategoryId);
            documentUploadViewModel.DocTypes = _mapper.ProjectTo<DocTypeCustomViewModel>(docTypes, _mapper.ConfigurationProvider).ToList();

            var docs = _appDocumentService.GetObjectDocuments(entityName, objectId, docCategoryId);
            documentUploadViewModel.Docs =
                _mapper.ProjectTo<AppDocumentListViewModel>(docs, _mapper.ConfigurationProvider).ToList();
            return documentUploadViewModel;
        }

        [HttpPost("UploadFile")]
        public ActionResult UploadFile(int? docCategoryId, int appEntityId, int docTypeId, int? docId, int objectId)
        {
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var res = _appDocumentService.SaveDocument(docCategoryId, appEntityId, docTypeId, docId, objectId,
                        Request.Form.Files[0]);
                    if (!res)
                    {
                        Response.StatusCode = 400;
                    }
                }
            }
            catch
            {
                Response.StatusCode = 400;
            }

            return new EmptyResult();
        }

        //
        // [HttpGet("GetImage")]
        // public HttpResponseMessage GetImage(int appDocumentId)
        // {
        //     var appDoc = _appDocumentService.Get(appDocumentId,true);
        //     MemoryStream ms = new MemoryStream(appDoc.DocumentFile);
        //     HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StreamContent(ms)};
        //     response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(appDoc.ContentType);
        //     return response;
        // }
        [HttpGet("GetFile")]
        public FileContentResult GetFile(int appDocumentId)
        {
            var appDoc = _appDocumentService.GetFile(appDocumentId);
            return File(appDoc.DocumentFile, appDoc.ContentType);
            //return appDoc.DocumentFile;
        }

    }
}