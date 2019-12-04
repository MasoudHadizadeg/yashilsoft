using System;
using System.Threading.Tasks;
using System.Transactions;
using Yashil.Core.Interfaces;

namespace Yashil.Dashboard.Web.Data
{
    public class UnitOfWork
    {
        /*: IUnitOfWork
    {
        private YashilAppDbContext DbContext { get; set; }
        public UnitOfWork(YashilAppDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public int Commit()
        {
            int result;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = DbContext.SaveChanges();
                scope.Complete();
            }
            return result;
        }

        public async Task<int> CommitAsync()
        {
            int result;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await DbContext.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

    }*/
    }
}