using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
    public class EducationalCenterRepository : GenericApplicationBasedRepository<EducationalCenter, int>,
        IEducationalCenterRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public EducationalCenterRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public override IQueryable<EducationalCenter> GetAll(bool readOnly = false)
        {
            var additionalUserProp = _context.AdditionalUserProp.AsNoTracking().FirstOrDefault(x => x.UserId == _userPrincipal.Id);
            if (additionalUserProp != null)
            {
                return base.GetAll(readOnly).Where(x => x.Id == additionalUserProp.EducationalCenterId);
            }
            return base.GetAll(readOnly);
        }
    }
}