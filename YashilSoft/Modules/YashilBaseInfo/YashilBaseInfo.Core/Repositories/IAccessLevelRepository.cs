
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Repositories
{
    public interface IAccessLevelRepository : IGenericRepository<AccessLevel, int>
    {
        string GetDescription(int id);

    }
}
