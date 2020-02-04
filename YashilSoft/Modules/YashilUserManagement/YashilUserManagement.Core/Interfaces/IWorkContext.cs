using System.Security.Claims;

namespace YashilUserManagement.Core.Interfaces
{
    public interface IWorkContext
    {
        ClaimsPrincipal CurrentUser { get; set; }
    }
}
