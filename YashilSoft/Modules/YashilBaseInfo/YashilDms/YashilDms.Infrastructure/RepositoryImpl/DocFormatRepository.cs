			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilDms.Core.Repositories;

namespace YashilDms.Infrastructure.RepositoryImpl
{
	public class DocFormatRepository : GenericRepository<DocFormat,int>, IDocFormatRepository
    {
        private readonly YashilAppDbContext _context;
		public DocFormatRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
