using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilReport.Core.Services;
using YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt.Controllers
{
    public class ReportGroupController : BaseController<ReportGroup, int, ReportGroupListViewModel,  ReportGroupEditModel, ReportGroupSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IReportGroupService _reportGroupService;
        public ReportGroupController(IReportGroupService reportGroupService, IMapper mapper) : base(reportGroupService, mapper)
        {
            _mapper = mapper;
            _reportGroupService = reportGroupService;
        }
        [HttpGet("GetAssignedListAsync")]
        public async Task<LoadResult> GetAssignedListAsync(CustomDataSourceLoadOptions loadOptions, int id)
        {
            var entities = _reportGroupService.GetByReportId(id);
            return await DataSourceLoader.LoadAsync(entities.ProjectTo<ReportGroupSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetNotAssignedListAsync")]
        public async Task<LoadResult> GetNotAssignedListAsync(CustomDataSourceLoadOptions loadOptions, int id)
        {
            var entities = _reportGroupService.GetNotAssignedToReportId(id);
            return await DataSourceLoader.LoadAsync(entities.ProjectTo<ReportGroupSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetReportGroupList")]
        public async Task<List<ReportGroupViewModel>> GetReportGroupList()
        {
            return await _reportGroupService.GetReportGroupList().ProjectTo<ReportGroupViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}