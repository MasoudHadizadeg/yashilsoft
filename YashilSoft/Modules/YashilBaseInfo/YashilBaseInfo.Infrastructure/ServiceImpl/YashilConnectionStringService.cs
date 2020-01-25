using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Common.SharedKernel.Helpers;
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
            IYashilConnectionStringRepository yashilConnectionStringRepository, IUserPrincipal userPrincipal) : base(
            unitOfWork,
            yashilConnectionStringRepository, userPrincipal)
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
            return CryptographyHelper.AesDecrypt(
                _yashilConnectionStringRepository.GetConnectionStringByName(connectionName));
        }

        public IQueryable<YashilConnectionString> GetByReportId(int reportId)
        {
            return _yashilConnectionStringRepository.GetByReportId(reportId);
        }

        public YashilConnectionString FindByName(string connectionName)
        {
            return _yashilConnectionStringRepository.FindByName(connectionName);
        }

        public string Decrypt(string connectionString)
        {
            return CryptographyHelper.AesDecrypt(connectionString);
        }

        public override Task<ValueTask<YashilConnectionString>?> UpdateAsync(
            YashilConnectionString yashilConnectionString, object key, List<string> modifiedProperties,
            bool saveAfterUpdate = false)
        {
            yashilConnectionString.ConnectionString =
                CryptographyHelper.AesEncrypt(yashilConnectionString.ConnectionString);
            return base.UpdateAsync(yashilConnectionString, key, modifiedProperties, saveAfterUpdate);
        }

        public override Task<YashilConnectionString> AddAsync(YashilConnectionString yashilConnectionString,
            bool saveAfterAdd = false)
        {
            yashilConnectionString.ConnectionString =
                CryptographyHelper.AesEncrypt(yashilConnectionString.ConnectionString);
            return base.AddAsync(yashilConnectionString, saveAfterAdd);
        }
    }
}