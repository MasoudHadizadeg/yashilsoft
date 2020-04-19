	using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class PersonBankAccountService : GenericService<PersonBankAccount,int>, IPersonBankAccountService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonBankAccountRepository _personBankAccountRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public PersonBankAccountService (IUnitOfWork unitOfWork, IPersonBankAccountRepository personBankAccountRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, personBankAccountRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_personBankAccountRepository = personBankAccountRepository;
			_userPrincipal = userPrincipal;
        }
                 
        public IQueryable<PersonBankAccount> GetByCustomFilter( int? personId, int? bankType, int? representationId)
        {
            return _personBankAccountRepository.GetByCustomFilter(personId,bankType, representationId);
        }
           

    }
}      
 