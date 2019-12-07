namespace CodeGeneratorGreen.Models
{
    public class ModuleInfo
    {
        public string AreaName { get; set; }
        public string AngularModuleName { get; set; }
        public string ClassNamespace { get; set; }
        public string XmlFileName { get; set; }
        public bool GenerateProjectFiles { get; set; }
        public bool GenerateControllers { get; set; }
        public bool GenerateViewModels { get; set; }
        public bool GenerateServices { get; set; }
        public bool GenerateRepositories { get; set; }
    }
}