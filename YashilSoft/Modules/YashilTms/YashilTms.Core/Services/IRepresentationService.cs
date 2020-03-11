using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
    public interface IRepresentationService : IGenericService<Representation, int>
    {
        IQueryable<Representation> GetByEducationalCenterId(int educationalCenterId);
    }
}