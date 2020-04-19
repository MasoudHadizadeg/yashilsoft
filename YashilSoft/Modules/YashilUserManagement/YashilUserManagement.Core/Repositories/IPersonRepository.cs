using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person, int>
    {
        string GetDescription(int id);

        bool CheckExistsNationalCode(string nationalCode, int? personId);
    }
}