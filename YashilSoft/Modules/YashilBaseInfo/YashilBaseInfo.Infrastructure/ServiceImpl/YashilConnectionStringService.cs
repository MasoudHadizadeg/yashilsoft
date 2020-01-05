using System.Collections.Generic;
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
    public class YashilConnectionStringService : GenericService<YashilConnectionString, int>,
        IYashilConnectionStringService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IYashilConnectionStringRepository _yashilConnectionStringRepository;

        public YashilConnectionStringService(IUnitOfWork unitOfWork,
            IYashilConnectionStringRepository yashilConnectionStringRepository) : base(unitOfWork,
            yashilConnectionStringRepository)
        {
            _unitOfWork = unitOfWork;
            _yashilConnectionStringRepository = yashilConnectionStringRepository;
        }

        public List<YashilConnectionString> FindByIds(IEnumerable<int> connectionStringIds)
        {
            return _yashilConnectionStringRepository.FindByIds(connectionStringIds);
        }

        public string GetConnectionStringByName(string connectionName)
        {
            return _yashilConnectionStringRepository.GetConnectionStringByName(connectionName);
        }

        public IQueryable<YashilConnectionString> GetByReportId(int reportId)
        {
            return _yashilConnectionStringRepository.GetByReportId(reportId);
        }

        public YashilConnectionString FindByName(string connectionName)
        {
            return _yashilConnectionStringRepository.FindByName(connectionName);
        }
    }
}