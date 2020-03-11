using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Core.ControllersExtenders;
using Yashil.Core.CustomViewModels;
using Yashil.Core.Entities;

namespace Yashil.WebHost.ControllersDefaultExtenders
{
    public class UserControllerDefaultExtender: IUserControllerExtender
    {
        public void BeforeUpdate(List<object> editModelKeyValues, int userId)
        {
            
        }

        public List<object> GetCustomProps(int id)
        {
            return null;
        }

        public void BeforeInsert(User modelKeyValues, List<object> editModelKeyValues, int userId)
        {
        }
    }
}
