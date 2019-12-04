using System;

namespace Yashil.Common.SharedKernel.Module
{
    public class MissingModuleManifestException : Exception
    {
        public string ModuleName { get;}

        public MissingModuleManifestException()
        {

        }

        public MissingModuleManifestException(string message)
            : base(message)
        {

        }

        public MissingModuleManifestException(string message, string moduleName)
            :this(message)
        {
            ModuleName = moduleName;
        }
    }
}