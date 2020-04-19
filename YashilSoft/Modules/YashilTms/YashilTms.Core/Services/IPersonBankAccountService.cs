
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface IPersonBankAccountService : IGenericService<PersonBankAccount,int>
    {
                 
        IQueryable<PersonBankAccount> GetByCustomFilter( int? personId, int? bankType, int? representationId);
           
		
    }
}      
 