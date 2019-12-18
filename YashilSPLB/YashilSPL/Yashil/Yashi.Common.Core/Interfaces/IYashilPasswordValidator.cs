using System.Threading.Tasks;
using Yashil.Common.Core.Dtos;

namespace Yashil.Common.Core.Interfaces
{
    public interface IYashilPasswordValidator<PK>
    {
       Task<UserValidationResaultViewModel<PK>> ValidateUserAndPassword(LoginViewModel loginViewModel);
    }
}
