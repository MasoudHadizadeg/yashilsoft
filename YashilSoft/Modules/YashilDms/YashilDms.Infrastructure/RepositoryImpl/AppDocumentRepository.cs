using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilDms.Core.Repositories;

namespace YashilDms.Infrastructure.RepositoryImpl
{
    public class AppDocumentRepository : GenericApplicationBasedRepository<AppDocument, int>, IAppDocumentRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public AppDocumentRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public IQueryable<AppDocument> GetObjectDocuments(int entityId, int objectId)
        {
            return DbSet.Where(x => x.DocType.AppEntityId == entityId && x.ObjectId == objectId).Where(ApplicationBasedDefaultFilter());
        }
    }
}