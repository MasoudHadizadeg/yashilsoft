using System.Collections;
using System.Linq;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace Yashil.Dashboard.Web.BaseClasses
{
    [ModelBinder(BinderType = typeof(CustomDataSourceLoadOptionsBinder))]
    public class CustomDataSourceLoadOptions : DataSourceLoadOptionsBase
    {
        public IList CustomParams { get; set; }

        public string GetParam(string paramName)
        {
            if (CustomParams==null)
            {
                return null;
            }
            foreach (Newtonsoft.Json.Linq.JContainer loadOptionsCustomParam in CustomParams)
            {
                if (loadOptionsCustomParam.HasValues && loadOptionsCustomParam.Any())
                {
                    if (loadOptionsCustomParam[0].ToString() == paramName)
                    {
                        return loadOptionsCustomParam[1].ToString();
                    }
                }
            }

            return null;
        }
    }
}