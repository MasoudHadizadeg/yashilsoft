using System.Runtime.Serialization;

namespace YashilReport.Core
{
    [DataContract]
    public class Result
    {
        [DataMember(Name = "success")] public bool Success { get; set; }

        [DataMember(Name = "notice")] public string Notice { get; set; }

        [DataMember(Name = "columns")] public string[] Columns { get; set; }

        [DataMember(Name = "rows")] public string[][] Rows { get; set; }

        [DataMember(Name = "types")] public string[] Types { get; set; }
    }
}