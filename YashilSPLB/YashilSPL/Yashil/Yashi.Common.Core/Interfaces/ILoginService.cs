using System.Threading.Tasks;
using Yashil.Common.Core.Dtos;

namespace Yashil.Common.Core.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResultModel> Login(LoginViewModel model);
    }
}
