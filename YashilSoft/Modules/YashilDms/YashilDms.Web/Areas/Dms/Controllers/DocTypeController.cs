	 
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDms.Core.Services;
using  YashilDms.Web.Areas.Dms.ViewModels;

namespace YashilDms.Web.Areas.Dms.Controllers
{
	public class DocTypeController : BaseController<DocType ,int,DocTypeListViewModel, DocTypeEditModel,DocTypeSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDocTypeService _docTypeService;
        public DocTypeController(IDocTypeService docTypeService, IMapper mapper) : base(docTypeService, mapper)
        {
            _mapper=mapper;
            _docTypeService=docTypeService;
        }
        [HttpGet("GetEntitiesByAppEntityName")]
        public async Task<LoadResult> GetEntitiesByAppEntityName(CustomDataSourceLoadOptions loadOptions, string appEntityName)
        {
            return await DataSourceLoader.LoadAsync(_docTypeService.GetEntitiesByAppEntityName(appEntityName)
                .ProjectTo<DocTypeListViewModel>(this._mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetEntitiesByDocumentCategoryId")]
        public async Task<LoadResult> GetEntitiesByDocumentCategoryId(CustomDataSourceLoadOptions loadOptions, int documentCategoryId)
        {
            return await DataSourceLoader.LoadAsync(_docTypeService.GetEntitiesByDocumentCategoryId(documentCategoryId)
                .ProjectTo<DocTypeListViewModel>(this._mapper.ConfigurationProvider), loadOptions);
        }
    }
}      