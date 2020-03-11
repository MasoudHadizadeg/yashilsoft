using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Repositories
{
    public interface ICommonBaseDataRepository : IGenericRepository<CommonBaseData, int>
    {
        string GetExtendedProps(int id);
        string GetDescription(int id);
        IQueryable<CommonBaseData> GetByKeyName(string keyName);
    }
}