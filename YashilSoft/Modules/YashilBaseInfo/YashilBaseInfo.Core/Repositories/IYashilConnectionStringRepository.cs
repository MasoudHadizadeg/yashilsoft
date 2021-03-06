using System.Collections.Generic;
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Repositories
{
    public interface IYashilConnectionStringRepository : IGenericRepository<YashilConnectionString, int>
    {
        List<YashilConnectionString> FindByIds(IEnumerable<int> connectionStringIds);
        string GetConnectionStringByName(string connectionName);
        IQueryable<YashilConnectionString> GetByReportId(int reportId);
        YashilConnectionString FindByName(string connectionName);
    }
}