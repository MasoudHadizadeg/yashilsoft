namespace Yashil.Runtime.Classes
{
    public interface IAppSettings
    {
        string Secret { get; set; }
        string AESKey { get; set; }
        string AESIv { get; set; }
    }

    public class AppSettings : IAppSettings
    {
        public string Secret { get; set; }
        public string AESKey { get; set; }
        public string AESIv { get; set; }
    }
}