using System.Collections.Generic;

namespace Yashil.Common.SharedKernel.Module
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<ModuleInfo> GetModules();
    }
}