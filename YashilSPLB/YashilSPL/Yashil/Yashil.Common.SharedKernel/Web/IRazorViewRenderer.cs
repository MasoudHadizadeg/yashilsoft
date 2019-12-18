using System.Threading.Tasks;

namespace Yashil.Common.SharedKernel.Web
{
    public interface IRazorViewRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
