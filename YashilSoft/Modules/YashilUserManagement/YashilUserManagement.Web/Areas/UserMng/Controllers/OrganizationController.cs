	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class OrganizationController : BaseController<Organization ,int,OrganizationListViewModel,  OrganizationEditModel,OrganizationSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService, IMapper mapper) : base(organizationService, mapper)
        {
            _mapper=mapper;
            _organizationService=organizationService;
        }
    }
}      