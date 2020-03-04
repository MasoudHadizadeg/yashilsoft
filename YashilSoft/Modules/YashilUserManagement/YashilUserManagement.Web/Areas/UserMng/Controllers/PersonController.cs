	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class PersonController : BaseController<Person ,int,PersonListViewModel, PersonEditModel,PersonSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService, IMapper mapper) : base(personService, mapper)
        {
            _mapper=mapper;
            _personService=personService;
        }
    }
}      