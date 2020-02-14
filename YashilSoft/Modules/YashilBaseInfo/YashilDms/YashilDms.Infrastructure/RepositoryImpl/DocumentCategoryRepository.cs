			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilDms.Core.Repositories;

namespace YashilDms.Infrastructure.RepositoryImpl
{
	public class DocumentCategoryRepository : GenericRepository<DocumentCategory,int>, IDocumentCategoryRepository
    {
        private readonly YashilAppDbContext _context;
		public DocumentCategoryRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
