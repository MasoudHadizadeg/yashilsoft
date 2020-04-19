using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
    public class PersonService : GenericService<Person, int>, IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;
        private readonly IUserPrincipal _userPrincipal;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository, IUserPrincipal userPrincipal)
            : base(unitOfWork, personRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _userPrincipal = userPrincipal;
        }

        public string GetDescription(int id)
        {
            return _personRepository.GetDescription(id);
        }

        public bool CheckExistsNationalCode(string nationalCode, int? personId)
        {
            return _personRepository.CheckExistsNationalCode(nationalCode,personId);
        }
    }
}