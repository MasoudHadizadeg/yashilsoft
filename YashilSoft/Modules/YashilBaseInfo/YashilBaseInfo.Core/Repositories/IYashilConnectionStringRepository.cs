			
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilBaseInfo.Core.Repositories
{
	public interface IYashilConnectionStringRepository : IGenericRepository<YashilConnectionString>
    {
        List<YashilConnectionString> FindByIds(IEnumerable<int> connectionStringIds);
        string GetConnectionStringByName(string connectionName);
    }
}      
