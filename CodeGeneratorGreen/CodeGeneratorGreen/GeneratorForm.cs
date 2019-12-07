using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CodeGeneratorGreen.Classes;
using CodeGeneratorGreen.Extentions;
using CodeGeneratorGreen.Models;
using CodeGeneratorGreen.Templates.Angular;
using CodeGeneratorGreen.Templates.Angular.CRUD.ListForm;
using CodeGeneratorGreen.Templates.Angular.CRUD.PopopEditForm;
using CodeGeneratorGreen.Templates.CsharpClasses.ProjectTemplates;
using CodeGeneratorGreen.Templates.CsharpClasses.Repositories;
using CodeGeneratorGreen.Templates.CsharpClasses.Services;
using CodeGeneratorGreen.Templates.CsharpClasses.WebModule;
using CodeGeneratorGreen.Templates.CsharpClasses.WebModule.ProjectTemplates;

namespace CodeGeneratorGreen
{
    public partial class GeneratorForm : Form
    {
        public GeneratorForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("Files"))
            {
                Directory.Delete("Files", true);
            }

            var moduleInfos = new List<ModuleInfo>
            {
                new ModuleInfo
                {
                    ClassNamespace = "YashilDashboard", AngularModuleName = "Dashboard", AreaName = "Dash",
                    XmlFileName = "Data_Dash",GenerateProjectFiles=false
                },
                new ModuleInfo
                {
                    ClassNamespace = "YashilUserManagement", AngularModuleName = "UserManagement", AreaName = "UserMng",
                    XmlFileName = "Data_user",GenerateProjectFiles=false
                },
                new ModuleInfo
                {
                    ClassNamespace = "YashilReport", AngularModuleName = "Report", AreaName = "Rpt",
                    XmlFileName = "Data_Rpt",GenerateProjectFiles=false
                }
                ,
                new ModuleInfo
                {
                    ClassNamespace = "YashilBaseInfo", AngularModuleName = "BaseInfo", AreaName = "BaseInf",
                    XmlFileName = "Data_base",GenerateProjectFiles=false
                }
            };

            foreach (var moduleInfo in moduleInfos)
            {
                ApplicationInfo.Instance.ModuleInfo = moduleInfo;

                var reader = new System.Xml.Serialization.XmlSerializer(typeof(Tables));
                var file = new StreamReader($@"D:\Works\{moduleInfo.XmlFileName}.Xml");
                var tables = (Tables) reader.Deserialize(file);

                file.Close();
                SqlToCsharpHelper.dbTables = tables;

                foreach (var table in tables.TableList)
                {
                    SqlToCsharpHelper.table = table;
                    GenerateAngularListForm(table);
                    GenerateAngularListHtml(table);
                    GenerateAngularEditForm(table);
                    GenerateAngularEditHtmlForm(table);
                    GenerateController(table);
                    GenerateViewModels(table);
                    GenerateRepositories(table);
                    GenerateIRepositories(table);
                    GenerateIServices(table);
                    GenerateServices(table);
                }

                

                GenerateDomainProfile();
                GenerateAngularEntityEnum();
                GenerateAngularIndexFile();
                GenerateAngularEntryComponentFile();
                GenerateAngularRouter();
                GenerateAngularSidebarRoutes();
                GenerateAngularModule();
                GenerateModuleInitializer();
                GenerateModuleJsonTemplate();
                GenerateProgramTemplate();
                if (ApplicationInfo.Instance.ModuleInfo.GenerateProjectFiles)
                {
                    GenerateCoreCsproj();
                    GenerateCoreCsprojUser();
                    GenerateWebCsprojUser();
                    GenerateWebProjectCsproj();
                    GenerateInfrastructureCsprojTemplate();
                }
                
            }

            Application.Exit();
        }

        private void GenerateInfrastructureCsprojTemplate()
        {
            var infrastructureCsprojTemplate = new InfrastructureCsprojTemplate();
            var pageContent = infrastructureCsprojTemplate.TransformText();
            var path = ApplicationInfo.Instance.InfrastructureModuleRootPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{ApplicationInfo.Instance.ModuleInfo.ClassNamespace}.Infrastructure.csproj",
                pageContent);
        }

        private void GenerateWebProjectCsproj()
        {
            var webProjectCsproj = new WebProjectCsproj();
            var pageContent = webProjectCsproj.TransformText();
            var path = ApplicationInfo.Instance.WebModuleRootPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText($"{path}/{ApplicationInfo.Instance.ModuleInfo.ClassNamespace}.Web.csproj",
                pageContent);
        }

        private void GenerateProgramTemplate()
        {
            var moduleJsonTemplate = new ProgramTemplate();
            var pageContent = moduleJsonTemplate.TransformText();
            var path = ApplicationInfo.Instance.WebModuleRootPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText($"{path}/Program.cs",
                pageContent);
        }

        private void GenerateModuleJsonTemplate()
        {
            var moduleJsonTemplate = new ModuleJsonTemplate();
            var pageContent = moduleJsonTemplate.TransformText();
            var path = ApplicationInfo.Instance.WebModuleRootPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText($"{path}/module.json",
                pageContent);
        }

        private void GenerateModuleInitializer()
        {
            var moduleInitializerTemplate = new ModuleInitializerTemplate();
            var pageContent = moduleInitializerTemplate.TransformText();
            var path = ApplicationInfo.Instance.WebModuleRootPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText($"{path}/ModuleInitializer.cs",
                pageContent);
        }

        private void GenerateWebCsprojUser()
        {
            var webCsprojUser = new WebCsprojUser();
            var pageContent = webCsprojUser.TransformText();
            var path = ApplicationInfo.Instance.WebModuleRootPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText($"{path}/{ApplicationInfo.Instance.ModuleInfo.ClassNamespace}.Web.csproj.user",
                pageContent);
        }

        private void GenerateAngularModule()
        {
            var angularModueTemplate = new AngularModeuleTemplate();
            var pageContent = angularModueTemplate.TransformText();
            var path = $"Files/{ApplicationInfo.Instance.AngularModuleRootPath}/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{ApplicationInfo.Instance.AngularModuleName.ToAngularFrendlyName()}.module.ts",
                pageContent);
        }

        private void GenerateAngularSidebarRoutes()
        {
            if (!ApplicationInfo.Instance.AngularModuleIsLazy)
            {
                var sidebarRoutesconfigTemplate = new SidebarRoutesconfigTemplate();
                var pageContent = sidebarRoutesconfigTemplate.TransformText();
                var path = $"Files/{ApplicationInfo.Instance.AngularModuleRootPath}/";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                File.WriteAllText(
                    $"{path}/sidebar-routes.config.ts",
                    pageContent);
            }
        }

        private void GenerateAngularRouter()
        {
            var pageContent = ApplicationInfo.Instance.AngularModuleIsLazy
                ? new AngularRouterTemplateForLazyModules().TransformText()
                : new AngularRouterTemplate().TransformText();


            var path = $"Files/{ApplicationInfo.Instance.AngularModuleRootPath}/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{ApplicationInfo.Instance.AngularModuleName.ToAngularFrendlyName()}-routing.module.ts",
                pageContent);
        }

        private void GenerateAngularIndexFile()
        {
            var angularIndexFileGenerator = new AngularIndexFileGenerator();
            var pageContent = angularIndexFileGenerator.TransformText();
            var path = $"Files/{ApplicationInfo.Instance.AngularModuleRootPath}/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/index.ts",
                pageContent);
        }

        private void GenerateAngularEntryComponentFile()
        {
            var angularentryComponentsGenerator = new AngularEntryComponentsGenerator();
            var pageContent = angularentryComponentsGenerator.TransformText();
            var path = $"Files/{ApplicationInfo.Instance.AngularModuleRootPath}/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/entryIndex.ts",
                pageContent);
        }

        private void GenerateAngularEntityEnum()
        {
            var angularEntityEnum = new AngularEntityEnum();
            var pageContent = angularEntityEnum.TransformText();
            var path = $"Files";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/entity.enum.ts",
                pageContent);
        }

        private void GenerateAngularListHtml(Table table)
        {
            var angularListHtmlForm = new AngularListHtml();
            var pageContent = angularListHtmlForm.TransformText();
            var path =
                $"Files/{ApplicationInfo.Instance.AngularModuleRootPath}/{table.Name.ToAngularFrendlyName()}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{table.Name.ToAngularFrendlyName()}-list.component.html",
                pageContent);
        }

        private void GenerateAngularEditHtmlForm(Table table)
        {
            var angularEdithtmlForm = new AngularEditHtml();
            var pageContent = angularEdithtmlForm.TransformText();
            var path =
                $"Files/{ApplicationInfo.Instance.AngularModuleRootPath}/{table.Name.ToAngularFrendlyName()}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{table.Name.ToAngularFrendlyName()}-detail.component.html",
                pageContent);
        }

        private void GenerateAngularEditForm(Table table)
        {
            var angularEditForm = new AngularEditForm();
            var pageContent = angularEditForm.TransformText();
            var path =
                $"Files/{ApplicationInfo.Instance.AngularModuleRootPath}/{table.Name.ToAngularFrendlyName()}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{table.Name.ToAngularFrendlyName()}-detail.component.ts",
                pageContent);
        }

        private void GenerateAngularListForm(Table table)
        {
            var angularListForm = new AngularListForm();
            var pageContent = angularListForm.TransformText();
            var path =
                $"Files/{ApplicationInfo.Instance.AngularModuleRootPath}/{table.Name.ToAngularFrendlyName()}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{table.Name.ToAngularFrendlyName()}-list.component.ts",
                pageContent);
        }

        private void GenerateDomainProfile()
        {
            var domainProfileTemplate = new DomainProfileTemplate();
            var pageContent = domainProfileTemplate.TransformText();
            var path = ApplicationInfo.Instance.DomainProfilePath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText($"{path}/{ApplicationInfo.Instance.ClassNamespace}DomainProfile.cs",
                pageContent);
        }

        private void GenerateRepositories(Table table)
        {
            var repositoryTemplate = new RepositoryTemplate();
            var pageContent = repositoryTemplate.TransformText();
            var path = ApplicationInfo.Instance.RepositoryFilePath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{table.Name}Repository.cs",
                pageContent);
        }

        private void GenerateIRepositories(Table table)
        {
            var repositoryTemplate = new IRepositoryTemplate();
            var pageContent = repositoryTemplate.TransformText();
            var path = ApplicationInfo.Instance.IRepositoryFilePath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/I{table.Name}Repository.cs",
                pageContent);
        }

        private void GenerateCoreCsproj()
        {
            var repositoryTemplate = new CoreProjectCsproj();
            var pageContent = repositoryTemplate.TransformText();
            var path = ApplicationInfo.Instance.CoreModuleRootPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{ApplicationInfo.Instance.ClassNamespace}.Core.csproj",
                pageContent);
        }

        private void GenerateCoreCsprojUser()
        {
            var repositoryTemplate = new CoreCsprojUser();
            var pageContent = repositoryTemplate.TransformText();
            var path = ApplicationInfo.Instance.CoreModuleRootPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{ApplicationInfo.Instance.ClassNamespace}.Core.csproj.user",
                pageContent);
        }

        private void GenerateIServices(Table table)
        {
            var repositoryTemplate = new IServiceTemplate();
            var pageContent = repositoryTemplate.TransformText();
            var path = ApplicationInfo.Instance.IServiceFilePath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/I{table.Name}Service.cs",
                pageContent);
        }

        private void GenerateServices(Table table)
        {
            var repositoryTemplate = new ServiceTemplate();
            var pageContent = repositoryTemplate.TransformText();
            var path = ApplicationInfo.Instance.ServiceFilePath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{table.Name}Service.cs",
                pageContent);
        }

        private void GenerateViewModels(Table table)
        {
            var viewModelsTemplate = new ViewModelsTemplate();
            var pageContent = viewModelsTemplate.TransformText();
            var path = ApplicationInfo.Instance.ViewModelsPath;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{table.Name}ViewModel.cs",
                pageContent);
        }

        private void GenerateController(Table table)
        {
            var angularListHtmlForm = new ControllerTemplate();
            var pageContent = angularListHtmlForm.TransformText();
            var path = ApplicationInfo.Instance.ControllersPath; // $"Files/Controllers";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(
                $"{path}/{table.Name}Controller.cs",
                pageContent);
        }
    }
}