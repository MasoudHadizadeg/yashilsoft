using System.Linq;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilDms.Core.Repositories;

namespace YashilDms.Infrastructure.RepositoryImpl
{
    public class DocTypeRepository : GenericApplicationBasedRepository<DocType, int>, IDocTypeRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public DocTypeRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public IQueryable<DocType> GetEntityDocTypes(int entityId)
        {
            return DbSet.Where(x => x.AppEntityId == entityId).Include(x => x.DocFormat)
                .Where(ApplicationBasedDefaultFilter());
        }
    }
}