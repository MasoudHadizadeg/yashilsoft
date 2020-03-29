using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
    public class RepresentationRepository : GenericApplicationBasedRepository<Representation, int>,
        IRepresentationRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public RepresentationRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public override IQueryable<Representation> GetAll(bool readOnly = false)
        {
            var query = base.GetAll(readOnly);
            var additionalUserProp = _context.AdditionalUserProp.AsNoTracking()
                .FirstOrDefault(x => x.UserId == _userPrincipal.Id);
            if (additionalUserProp != null)
            {
                if (additionalUserProp.RepresentationId.HasValue)
                    query = query.Where(x => x.Id == additionalUserProp.RepresentationId);
                else
                    query = query.Where(x => x.EducationalCenterId == additionalUserProp.EducationalCenterId);
            }
            return query;
        }

        public IQueryable<Representation> GetByEducationalCenterId(int educationalCenterId)
        {
            return GetAll(true).Where(x => x.EducationalCenterId == educationalCenterId);
        }
    }
}