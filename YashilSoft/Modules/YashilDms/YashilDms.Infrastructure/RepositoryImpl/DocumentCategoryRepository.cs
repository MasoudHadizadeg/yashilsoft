using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilDms.Core.Repositories;

namespace YashilDms.Infrastructure.RepositoryImpl
{
    public class DocumentCategoryRepository : GenericApplicationBasedRepository<DocumentCategory, int>,
        IDocumentCategoryRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public DocumentCategoryRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public DocumentCategory GetDocumentDefaultCategory(int appEntityId)
        {
            return DbSet.Where(x => !x.ParentId.HasValue && x.AppEntityId == appEntityId).OrderBy(x => x.Id).FirstOrDefault();
        }

        public IQueryable<DocumentCategory> GetAll(string appEntityName)
        {
            return GetAll(true).Where(x => x.AppEntity.Title == appEntityName);
        }

        public IQueryable<DocumentCategory> GetAll(int appEntityId)
        {
            return GetAll(true).Where(x => x.AppEntityId == appEntityId);
        }
    }
}