using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
    public interface IAdditionalUserPropService : IGenericService<AdditionalUserProp, int>
    {
        AdditionalUserProp GetByUserId(int userId);
    }
}