using System.Security.Claims;

namespace YashilUserManagement.Core.Interfaces
{
    public interface IWorkContext
    {
        public ClaimsPrincipal CurrentUser { get; set; }
    }
}
