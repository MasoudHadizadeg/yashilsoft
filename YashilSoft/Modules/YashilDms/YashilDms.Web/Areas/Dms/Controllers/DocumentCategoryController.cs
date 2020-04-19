using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using YashilDms.Core.Services;
using YashilDms.Web.Areas.Dms.ViewModels;

namespace YashilDms.Web.Areas.Dms.Controllers
{
    public class DocumentCategoryController : BaseController<DocumentCategory, int, DocumentCategoryListViewModel,
        DocumentCategoryEditModel, DocumentCategorySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentCategoryService _documentCategoryService;
        public DocumentCategoryController(IDocumentCategoryService documentCategoryService, IMapper mapper, IAppEntityService appEntityService) : base(
            documentCategoryService, mapper)
        {
            _mapper = mapper;
            _documentCategoryService = documentCategoryService;
        }

        [HttpGet("GetEntitiesByAppEntityName")]
        public async Task<LoadResult> GetEntitiesByAppEntityName(CustomDataSourceLoadOptions loadOptions, string appEntityName)
        {
            return await DataSourceLoader.LoadAsync<DocumentCategoryListViewModel>(_documentCategoryService.GetAll(appEntityName)
                .ProjectTo<DocumentCategoryListViewModel>(this._mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetEntitiesByAppEntityId")]
        public async Task<LoadResult> GetEntitiesByAppEntityId(CustomDataSourceLoadOptions loadOptions, int appEntityId)
        {
            return await DataSourceLoader.LoadAsync<DocumentCategoryListViewModel>(_documentCategoryService.GetAll(appEntityId)
                .ProjectTo<DocumentCategoryListViewModel>(this._mapper.ConfigurationProvider), loadOptions);
        }
    }
}