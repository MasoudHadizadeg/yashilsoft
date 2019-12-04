using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Yashil.Dashboard.Web.BaseClasses
{
    public class CustomDataSourceLoadOptionsBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            CustomDataSourceLoadOptions sourceLoadOptions = new CustomDataSourceLoadOptions();
            DataSourceLoadOptionsParser.Parse((DataSourceLoadOptionsBase) sourceLoadOptions,
                (Func<string, string>) (key => bindingContext.ValueProvider.GetValue(key).FirstOrDefault<string>()));

            string customParams = bindingContext.ValueProvider.GetValue("customParams").FirstOrDefault<string>();
            if (customParams != null)
            {
                sourceLoadOptions.CustomParams = JsonConvert.DeserializeObject<IList>(customParams,
                    new JsonSerializerSettings()
                    {
                        DateParseHandling = DateParseHandling.None
                    });
            }


            bindingContext.Result = ModelBindingResult.Success((object) sourceLoadOptions);
            return (Task) Task.FromResult<bool>(true);
        }
    }
}