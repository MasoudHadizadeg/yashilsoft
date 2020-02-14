			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilDms.Core.Repositories;

namespace YashilDms.Infrastructure.RepositoryImpl
{
	public class DocTypeRepository : GenericRepository<DocType,int>, IDocTypeRepository
    {
        private readonly YashilAppDbContext _context;
		public DocTypeRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
