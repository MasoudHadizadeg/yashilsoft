using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yashil.Common.Core.Interfaces
{
    public interface IWorkContext<T>
    {
        Task<IUser<T>> GetCurrentUser();
    }
}