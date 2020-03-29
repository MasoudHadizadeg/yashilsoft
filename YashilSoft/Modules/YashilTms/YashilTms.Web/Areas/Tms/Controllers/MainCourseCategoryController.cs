using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
    public class MainCourseCategoryController : BaseController<MainCourseCategory, int, MainCourseCategoryListViewModel,
        MainCourseCategoryEditModel, MainCourseCategorySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IMainCourseCategoryService _mainCourseCategoryService;

        public MainCourseCategoryController(IMainCourseCategoryService mainCourseCategoryService, IMapper mapper) :
            base(mainCourseCategoryService, mapper)
        {
            _mapper = mapper;
            _mainCourseCategoryService = mainCourseCategoryService;
        }
       
    }
}