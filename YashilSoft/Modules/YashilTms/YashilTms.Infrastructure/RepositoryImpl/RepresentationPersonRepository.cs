			using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
	public class RepresentationPersonRepository : GenericApplicationBasedRepository<RepresentationPerson,int>, IRepresentationPersonRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
		public RepresentationPersonRepository (YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,userPrincipal)
            {
                _context = context;
                _userPrincipal = userPrincipal;
            }

        public IQueryable<RepresentationPerson> GetByRepresentationId(int representationId)
        {
            return GetAll(true).Where(x => x.RepresentationId == representationId);
        }

        public IQueryable<RepresentationPerson> GetByCustomFilter(int? representationId, int? personId, int? postId)
        {
            var query = GetAll(true);
            if (representationId.HasValue)
            {
                query = query.Where(x => x.RepresentationId == representationId.Value);
            }
            if (personId.HasValue)
            {
                query = query.Where(x => x.PersonId == personId.Value);
            }
            if (postId.HasValue)
            {
                query = query.Where(x => x.PostId == postId.Value);
            }
            return query;
        }

    }
}      
