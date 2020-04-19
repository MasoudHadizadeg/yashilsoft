	 
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class PersonBankAccountController : BaseController<PersonBankAccount ,int,PersonBankAccountListViewModel, PersonBankAccountEditModel,PersonBankAccountSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonBankAccountService _personBankAccountService;
        public PersonBankAccountController(IPersonBankAccountService personBankAccountService, IMapper mapper) : base(personBankAccountService, mapper)
        {
            _mapper=mapper;
            _personBankAccountService=personBankAccountService;
        }
              [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions,  int? personId, int? bankType, int? representationId)
        {
            var personBankAccounts = _personBankAccountService.GetByCustomFilter(personId,bankType, representationId);
            return await DataSourceLoader.LoadAsync(personBankAccounts.ProjectTo<PersonBankAccountListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions,  int? personId, int? bankType,int? representationId)
        {
            var personBankAccounts = _personBankAccountService.GetByCustomFilter(personId,bankType, representationId);
            return await DataSourceLoader.LoadAsync(personBankAccounts.ProjectTo<PersonBankAccountSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
  
    }
}      