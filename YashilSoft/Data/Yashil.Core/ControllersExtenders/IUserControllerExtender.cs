using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Core.CustomViewModels;
using Yashil.Core.Entities;

namespace Yashil.Core.ControllersExtenders
{
    public interface IUserControllerExtender
    {
        void BeforeUpdate(List<object> editModelKeyValues, int userId);
        List<object> GetCustomProps(int id);
        void BeforeInsert(User modelKeyValues, List<object> editModelKeyValues, int userId);
    }
}