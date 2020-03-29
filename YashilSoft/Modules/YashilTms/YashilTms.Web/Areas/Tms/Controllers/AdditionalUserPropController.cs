using System.Threading.Tasks;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
    public class AdditionalUserPropController : BaseController<AdditionalUserProp, int, AdditionalUserPropListViewModel,
        AdditionalUserPropEditModel, AdditionalUserPropSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalUserPropService _additionalUserPropService;
        private readonly IUserPrincipal _userPrincipal;

        public AdditionalUserPropController(IAdditionalUserPropService additionalUserPropService, IMapper mapper,
            IUserPrincipal userPrincipal) : base(additionalUserPropService, mapper)
        {
            _mapper = mapper;
            _userPrincipal = userPrincipal;
            _additionalUserPropService = additionalUserPropService;
        }

        [HttpGet("GetCurrentUserAdditionalProp")]
        public AdditionalUserPropEditModel GetCurrentUserAdditionalProp()
        {
            var additionalUserProp = _additionalUserPropService.GetByUserId(_userPrincipal.Id);
            return _mapper.Map<AdditionalUserProp, AdditionalUserPropEditModel>(additionalUserProp);
        }
    }
}