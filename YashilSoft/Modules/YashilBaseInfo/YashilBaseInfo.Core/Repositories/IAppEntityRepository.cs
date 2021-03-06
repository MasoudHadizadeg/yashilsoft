using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Repositories
{
    public interface IAppEntityRepository : IGenericRepository<AppEntity, int>
    {
        string GetDescription(int id);
        string GetProps(int id);

        int GetIdByTitle(string editModelAppEntityTitle);
    }
}