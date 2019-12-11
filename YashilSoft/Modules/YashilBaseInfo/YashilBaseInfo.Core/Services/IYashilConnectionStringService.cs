			
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface IYashilConnectionStringService : IGenericService<YashilConnectionString>
    {
        List<YashilConnectionString> FindByIds(IEnumerable<int> connectionStringIds);
        string GetConnectionStringByName(string commandObjectConnection);
    }
}      
 