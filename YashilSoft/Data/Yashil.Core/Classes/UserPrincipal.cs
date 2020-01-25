using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Yashil.Core.Classes
{
    public interface IUserPrincipal
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }
    }

    public class UserPrincipal : IUserPrincipal
    {
        public UserPrincipal(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                Id = Convert.ToInt32(claimsPrincipal.Identity.Name);
                ApplicationId = Convert.ToInt32(claimsPrincipal.Claims
                    .FirstOrDefault(x => x.Type == YashilClaimTypes.ApplicationId)?.Value);
                OrganizationId = Convert.ToInt32(claimsPrincipal.Claims
                    .FirstOrDefault(x => x.Type == YashilClaimTypes.OrganizationId)?.Value);
            }
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }
    }
}