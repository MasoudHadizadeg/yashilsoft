using System.Collections.Generic;
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
    public interface IYashilConnectionStringService : IGenericService<YashilConnectionString, int>
    {
        List<YashilConnectionString> FindByIds(IEnumerable<int> connectionStringIds);

        /// <summary>
        /// Get Decrypted Connection String
        /// </summary>
        /// <param name="commandObjectConnection"></param>
        /// <returns></returns>
        string GetConnectionStringByName(string commandObjectConnection);

        /// <summary>
        /// Connections Are Encrypted
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        IQueryable<YashilConnectionString> GetByReportId(int reportId);

        /// <summary>
        /// Get Encrypted Connection String
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        YashilConnectionString FindByName(string connectionName);

        string Decrypt(string connectionString);
    }
}