using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        /// <param name="entityId"></param>
        /// <param name="objectId"></param>
        /// <returns></returns>
        [HttpGet("GetObjectDocuments")]
        public DocumentUploadViewModel GetObjectDocuments(int entityId, int objectId)
        {
            var documentUploadViewModel = new DocumentUploadViewModel();
            var docTypes = _docTypeService.GetEntityDocTypes(entityId);
            documentUploadViewModel.DocTypes = _mapper.ProjectTo<DocTypeCustomViewModel>(docTypes, _mapper.ConfigurationProvider).ToList();

            var docs = _appDocumentService.GetObjectDocuments(entityId, objectId);
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
    }
}