using System.Collections.Generic;
using System.IO.Pipes;
using CodeGeneratorGreen.Extentions;
using CodeGeneratorGreen.Models;

namespace CodeGeneratorGreen.Classes
{
    public class ApplicationInfo
    {
        private static ApplicationInfo _instance;

        public static ApplicationInfo Instance => _instance ?? (_instance = new ApplicationInfo());

        private ApplicationInfo()
        {
            ModuleInfo = new ModuleInfo();
        }

        public ModuleInfo ModuleInfo { get; set; }
        public string AreaName => ModuleInfo.AreaName;
        public string AngularModuleName => ModuleInfo.AngularModuleName;
        public string ClassNamespace => ModuleInfo.ClassNamespace;

        public List<string> skipedTables = new List<string> {"report-backup", "sysdiagrams", "TableDesc"};

        public List<string> skipedColumns = new List<string>
        {
            "CreateBy", "ModifyBy", "CreationDate", "Deleted", "ModificationDate", "ApplicationId",
            "CreatorOrganizationId"
        };

        public List<string> skipedColumnInAngularList = new List<string>
        {
            "Id", "Password", "PasswordSalt", "Deleted", "Description", "AccessLevel", "CreateBy", "ModifyBy",
            "CreationDate", "ModificationDate", "ApplicationId", "CreatorOrganizationId"
        };

        public List<string> SimpleViewModelColumns = new List<string>
            {"Id", "ParentId", "Title"};

        public string DbContextName = $"YashilAppDbContext";
        public string Infrastructure = "Infrastructure";
        public string Core = "Core";
        public string Web = "Web";
        public string Controllers = "Controllers";
        public string ServiceImpl = "ServiceImpl";
        public string Services = "Services";
        public string Repositories = "Repositories";
        public string RepositoryImpl = "RepositoryImpl";
        public string ViewModels = "ViewModels";

        public string WebModuleRootPath => $"Files/Modules/{ClassNamespace}/{ClassNamespace}.{Web}";

        public string WebModuleAreaPath => $"{WebModuleRootPath}/Areas/{AreaName}";

        public string ControllerNamespace => $"{ClassNamespace}.{Web}.Areas.{AreaName}.Controllers";
        public string ViewModelNamespace => $"{ClassNamespace}.Web.Areas.{AreaName}.{ViewModels}";
        public string RepositoryNamespace => $"{ClassNamespace}.{Infrastructure}.{RepositoryImpl}";
        public string IRepositoryNamespace => $"{ClassNamespace}.{Core}.{Repositories}";
        public string ServiceNamespace => $"{ClassNamespace}.{Infrastructure}.{ServiceImpl}";
        public string IServiceNamespace => $"{ClassNamespace}.{Core}.{Services}";
        public string AngularRootPath => "ClientApp/src/app";

        public bool AngularModuleIsLazy = true;

        public string AngularModuleRootPath => $"{AngularRootPath}/{AngularModuleName.ToAngularFrendlyName()}";
        public string DataNamespace => $"{ClassNamespace}.Data";


        public string IRepositoryFilePath =>
            $"Files/Modules/{ClassNamespace}/{ClassNamespace}.{Core}/{Repositories}";

        public string InfrastructureModuleRootPath =>
            $"Files/Modules/{ClassNamespace}/{ClassNamespace}.{Infrastructure}";

        public string RepositoryFilePath =>
            $"{InfrastructureModuleRootPath}/{RepositoryImpl}";

        public string ServiceFilePath =>
            $"{InfrastructureModuleRootPath}/{ServiceImpl}";

        public string CoreModuleRootPath => $"Files/Modules/{ClassNamespace}/{ClassNamespace}.{Core}";
        public string IServiceFilePath => $"{CoreModuleRootPath}/{Services}";
        public string ControllersPath => $"{WebModuleAreaPath}/{Controllers}";
        public string ViewModelsPath => $"{WebModuleAreaPath}/{ViewModels}";
        public string DomainProfilePath => $"{WebModuleAreaPath}";
    }
}