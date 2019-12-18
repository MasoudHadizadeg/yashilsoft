using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Yashil.Common.Core.Dtos
{
    public class UserValidationResaultViewModel<PK>
    {
        public bool IsSuccess { get; set; }
        public ClaimsIdentity ClaimsIdentity { get; set; }
        public PK UserId { get; set; }
        public string UserName { get; set; }
    }
}
