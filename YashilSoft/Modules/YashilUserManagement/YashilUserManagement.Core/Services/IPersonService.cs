			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Services
{
	public interface IPersonService : IGenericService<Person, int>
    {
			string GetDescription(int id);

            bool CheckExistsNationalCode(string nationalCode, int? personId);
    }
}      
 