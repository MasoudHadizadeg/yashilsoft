using System.Linq;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilTms.Core.Repositories;

namespace YashilTms.Infrastructure.RepositoryImpl
{
    public class PersonBankAccountRepository : GenericApplicationBasedRepository<PersonBankAccount, int>,
        IPersonBankAccountRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public PersonBankAccountRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }


        public IQueryable<PersonBankAccount> GetByCustomFilter(int? personId, int? bankType, int? representationId)
        {
            var query = GetAll(true);
            if (personId.HasValue)
            {
                query = query.Where(x => x.PersonId == personId.Value);
            }

            if (bankType.HasValue)
            {
                query = query.Where(x => x.BankType == bankType.Value);
            }
            if (representationId.HasValue)
            {
                var representation = _context.Representation.FirstOrDefault(x=>x.Id==representationId.Value);
                if (representation!=null)
                {
                    query = query.Where(x => x.PersonId == representation.FounderId);
                }
               
            }
            return query;
        }
    }
}