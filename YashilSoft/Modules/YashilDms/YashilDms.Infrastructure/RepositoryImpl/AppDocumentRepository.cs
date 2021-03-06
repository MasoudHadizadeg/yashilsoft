using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<AppDocument> GetObjectDocuments(string entityName, int objectId, int docCategoryId)
        {
            return DbSet.Where(x => x.DocType.DocumentCategory.AppEntity.Title == entityName && x.ObjectId == objectId &&
                                    x.DocType.DocumentCategoryId == docCategoryId).Where(ApplicationBasedDefaultFilter());
        }

        public int GetIdByTitle(string appEntityTitle)
        {
            return DbSet.Where(x => x.Title == appEntityTitle).Select(x => x.Id).FirstOrDefault();
        }

        public override AppDocument Get(object id, bool readOnly = false)
        {
            if (readOnly)
            {
                return DbSet.AsNoTracking().Include(x => x.DocType).FirstOrDefault(x => x.Id == (int) id);
            }

            return DbSet.Include(x => x.DocType).FirstOrDefault(x => x.Id == (int) id);
        }
    }
}