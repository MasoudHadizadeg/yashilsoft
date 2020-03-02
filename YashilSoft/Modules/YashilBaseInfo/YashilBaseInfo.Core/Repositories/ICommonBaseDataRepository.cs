			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilBaseInfo.Core.Repositories
{
	public interface ICommonBaseDataRepository : IGenericRepository<CommonBaseData>
    {
        IQueryable<CommonBaseData> GetByKeyName(string keyName);
    }
}      
