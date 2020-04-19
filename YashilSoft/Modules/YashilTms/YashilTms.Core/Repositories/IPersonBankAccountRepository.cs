			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface IPersonBankAccountRepository : IGenericRepository<PersonBankAccount,int>
    {
		          
        IQueryable<PersonBankAccount> GetByCustomFilter(int? personId, int? bankType, int? representationId);
           
		
    }
}      
 