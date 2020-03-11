			
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface IAdditionalUserPropRepository : IGenericRepository<AdditionalUserProp,int>
    {
        AdditionalUserProp GetByUserId(int userId);
    }
}      
 