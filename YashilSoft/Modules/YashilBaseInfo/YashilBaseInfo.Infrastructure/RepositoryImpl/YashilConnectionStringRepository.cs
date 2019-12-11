using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilBaseInfo.Core.Repositories;

namespace YashilBaseInfo.Infrastructure.RepositoryImpl
{
    public class YashilConnectionStringRepository : GenericRepository<YashilConnectionString, int>,
        IYashilConnectionStringRepository
    {
        private readonly YashilAppDbContext _context;

        public YashilConnectionStringRepository(YashilAppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<YashilConnectionString> FindByIds(IEnumerable<int> connectionStringIds)
        {
            return DbSet.Include(x => x.DataProvider).Where(x => connectionStringIds.Contains(x.Id)).ToList();
        }

        public string GetConnectionStringByName(string connectionName)
        {
            return DbSet.Where(x => x.Title == connectionName).Select(x => x.ConnectionString).FirstOrDefault();
        }
    }
}