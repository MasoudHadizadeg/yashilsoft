using Microsoft.AspNetCore.Mvc.Filters;

namespace Yashil.Common.Web.Infrastructure.Filters
{
    public class YashilExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            //ServiceLocator.Current.GetInstance<ILoggingService>().Log(context.Exception);
        }
    }
}
