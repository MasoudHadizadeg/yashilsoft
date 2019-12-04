using Microsoft.AspNetCore.Http;

namespace Yashil.Common.SharedKernel.Web
{
    public static class HttpRequestExtentions
    {
        public static string GetFullHostingUrlRoot(this HttpRequest request)
        {
            return $"{request.Scheme}://{request.Host.Value}";
        }
    }
}
