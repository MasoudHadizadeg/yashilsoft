using System.Runtime.Serialization;

namespace SimplCommerce.MSBuildTasks
{
    [DataContract]
    public class Module
    {
        [DataMember(Name ="id")]
        public string Id { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }

        [DataMember(Name = "subFolder")]
        public string SubFolder { get; set; }
        
        [DataMember(Name = "fullPath")]
        public string FullPath { get; set; }
    }
}
