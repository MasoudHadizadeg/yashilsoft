using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilBaseInfo.Core.Repositories;

namespace YashilBaseInfo.Infrastructure.RepositoryImpl
{
    public class CommonBaseDataRepository : GenericApplicationBasedRepository<CommonBaseData, int>,
        ICommonBaseDataRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public CommonBaseDataRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public string GetExtendedProps(int id)
        {
            return DbSet.Where(x => x.Id == id).Select(x => x.ExtendedProps).FirstOrDefault();
        }

        public string GetDescription(int id)
        {
            return DbSet.Where(x => x.Id == id).Select(x => x.Description).FirstOrDefault();
        }
        public IQueryable<CommonBaseData> GetByKeyName(string keyName)
        {
            return GetAll(true).Where(x => x.CommonBaseType.KeyName == keyName);
        }
    }
}