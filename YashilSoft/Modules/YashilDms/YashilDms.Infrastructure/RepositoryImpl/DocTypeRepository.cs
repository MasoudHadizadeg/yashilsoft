using System.Linq;
using System.Threading.Tasks;
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

        public override ValueTask<DocType> GetAsync(object id, bool readOnly = true)
        {

            int key = (int)id;
            var firstOrDefaultAsync = DbSet.Include(x => x.DocumentCategory).Include(x=>x.DocumentCategory.AppEntity)
                .FirstOrDefaultAsync(x => x.Id == key);
            return new ValueTask<DocType>(firstOrDefaultAsync);
        }

        public IQueryable<DocType> GetEntityDocTypes(string entityName, int docCategoryId)
        {
            return DbSet.Where(x => x.DocumentCategory.AppEntity.Title == entityName && x.DocumentCategoryId == docCategoryId)
                .Include(x => x.DocFormat).Where(ApplicationBasedDefaultFilter());
        }

        public IQueryable<DocType> GetEntitiesByAppEntityName(string appEntityName)
        {
            return GetAll(true).Include(x=>x.DocumentCategory.AppEntity).Where(x => x.DocumentCategory.AppEntity.Title == appEntityName);
        }

        public IQueryable<DocType> GetEntitiesByDocumentCategoryId(int documentCategoryId)
        {
            return GetAll(true).Where(x => x.DocumentCategoryId == documentCategoryId);
        }
    }
}