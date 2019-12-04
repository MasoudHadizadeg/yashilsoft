using System;

namespace Yashil.Common.Core.Interfaces
{
    public interface IBaseEntity<out T>
    {
        T Id { get; }
        int CreateBy { get; set; }
        int? ModifyBy { get; set; }
        bool Deleted { get; set; }
        DateTime CreationDate { get; set; }
        DateTime? ModificationDate { get; set; }
    }
}
