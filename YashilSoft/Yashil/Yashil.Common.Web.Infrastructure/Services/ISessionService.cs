namespace Yashil.Common.Web.Infrastructure.Services
{
    public interface ISessionService
    {
        string UserHostAddress { get; }

        object this[string key] { get; set; }

        T Get<T>(string key);

        string SessionId { get; }

        void Clear();
    }
}