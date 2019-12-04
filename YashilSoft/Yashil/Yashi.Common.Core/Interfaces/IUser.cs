using System.Collections.Generic;

namespace Yashil.Common.Core.Interfaces
{
    public interface IUser<T>
    {
        T Id { get; set; }
        Dictionary<string, string> Props { get; set; }
    }
}