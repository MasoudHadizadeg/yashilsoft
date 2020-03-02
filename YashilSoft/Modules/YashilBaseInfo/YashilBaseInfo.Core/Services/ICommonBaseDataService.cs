			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface ICommonBaseDataService : IGenericService<CommonBaseData>
    {
        IQueryable<CommonBaseData> GetByKeyName(string keyName);
    }
}      
 