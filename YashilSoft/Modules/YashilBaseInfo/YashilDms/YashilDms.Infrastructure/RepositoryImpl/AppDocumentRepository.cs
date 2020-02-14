			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilDms.Core.Repositories;

namespace YashilDms.Infrastructure.RepositoryImpl
{
	public class AppDocumentRepository : GenericRepository<AppDocument,int>, IAppDocumentRepository
    {
        private readonly YashilAppDbContext _context;
		public AppDocumentRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
