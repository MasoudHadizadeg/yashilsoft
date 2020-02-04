using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace SimplCommerce.MSBuildTasks
{
    public class CopyModuleTask : Task
    {
        private readonly string modulesFileName = "modules.json";
        private readonly string moduleFileName = "module.json";
        private readonly string bundleConfigFileName = "bundleconfig.json";

        [Required] public string ProjectDir { get; set; }

        [Required] public string BuildConfiguration { get; set; }

        [Required] public string TargetFramework { get; set; }

        public override bool Execute()
        {
            var modulesFilePath = Path.Combine(ProjectDir, modulesFileName);
            if (!File.Exists(modulesFilePath))
            {
                Log.LogError(modulesFilePath);
                Log.LogError($"{modulesFileName} is not found");
                return false;
            }

            var modules = new List<Module>();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(modulesFileName))))
            {
                var dataContractJsonSerializer = new DataContractJsonSerializer(modules.GetType());
                modules = dataContractJsonSerializer.ReadObject(ms) as List<Module>;
            }

            foreach (var module in modules)
            {
                var isSuccess = CopyModule(module);
                if (!isSuccess)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CopyModule(Module module)
        {
            Log.LogMessage(MessageImportance.High, $"Copied module  {module.Id} Start ...");
            if (module.Id == "Yashil.Runtime")
            {
                Log.LogMessage(module.Id);
                return true;
            }

            var directoryInfo = new DirectoryInfo(ProjectDir).Parent;
            if (directoryInfo != null)
            {
                var sourceRoot = Path.Combine(directoryInfo.FullName, "Modules", module.SubFolder,
                    module.Id);
                if (!string.IsNullOrWhiteSpace(module.FullPath))
                {
                    sourceRoot = Path.Combine(directoryInfo.FullName, module.FullPath, module.Id);
                }

                var moduleManifestFile = Path.Combine(sourceRoot, moduleFileName);
                if (!File.Exists(moduleManifestFile))
                {
                    Log.LogError(moduleManifestFile);
                    Log.LogError($"{moduleFileName} is not found for {module.Id}");
                    return false;
                }

                ModuleManifest moduleManifest = null;
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(moduleManifestFile))))
                {
                    var ser = new DataContractJsonSerializer(typeof(ModuleManifest));
                    moduleManifest = ser.ReadObject(ms) as ModuleManifest;
                }

                var destination = Path.Combine(ProjectDir, "Modules", module.SubFolder, module.Id);
                //var destinationWwwroot = Path.Combine(ProjectDir, "wwwroot", "modules", module.Id.Split('.').Last().ToLower());
                var destinationWwwroot = Path.Combine(ProjectDir, "wwwroot");

                try
                {
                    CreateOrCleanDirectory(destinationWwwroot);
                }
                catch (System.Exception e)
                {
                    Log.LogMessage(MessageImportance.High, $"Exception  {module.Id} *** >> CreateOrCleanDirectory(destinationWwwroot)  ");
                }

                try
                {
                    CreateOrCleanDirectory(destination);
                }
                catch (System.Exception e)
                {
                    Log.LogMessage(MessageImportance.High, $"Exception  {module.Id} *** >> CreateOrCleanDirectory(destination);  ");
                }


                File.Copy(Path.Combine(sourceRoot, moduleFileName),
                    Path.Combine(destination, moduleFileName), true);

                var bundleConfigFile = Path.Combine(sourceRoot, bundleConfigFileName);
                if (File.Exists(bundleConfigFile))
                {
                    File.Copy(Path.Combine(bundleConfigFile),
                        Path.Combine(destination, bundleConfigFileName), true);
                }

                CopyDirectory(Path.Combine(sourceRoot, "wwwroot"), destinationWwwroot);
                if (!moduleManifest.IsBundledWithHost)
                {
                    CopyDirectory(Path.Combine(sourceRoot, "bin", BuildConfiguration, TargetFramework),
                        Path.Combine(destination, "bin"));
                }

                if (module.Id == "SimplCommerce.Module.SampleData")
                {
                    CopyDirectory(Path.Combine(sourceRoot, "SampleContent"),
                        Path.Combine(destination, "SampleContent"));
                }
            }

            Log.LogMessage(MessageImportance.High, $"Copied module {module.Id}");
            return true;
        }

        private void CreateOrCleanDirectory(string path)
        {

            if (Directory.Exists(path))
            {
                var di = new DirectoryInfo(path);
                foreach (var file in di.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (System.Exception)
                    {
                        Log.LogMessage(MessageImportance.High, $"Exception file.Delete(); {path}");
                    }

                }

                foreach (var dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch (System.Exception)
                    {
                        Log.LogMessage(MessageImportance.High, $"Exception dir.Delete(true); {path}");
                    }

                }
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (System.Exception)
                {

                    Log.LogMessage(MessageImportance.High, $"Exception Directory.CreateDirectory(path);  {path}");
                }  
            }



        }

        private void CopyDirectory(string sourcePath, string targetPath)
        {
            if (!Directory.Exists(sourcePath))
            {
                return;
            }

            CopyAll(new DirectoryInfo(sourcePath), new DirectoryInfo(targetPath));
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (var file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }

            foreach (var subDirectory in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(subDirectory.Name);
                CopyAll(subDirectory, nextTargetSubDir);
            }
        }
    }
}