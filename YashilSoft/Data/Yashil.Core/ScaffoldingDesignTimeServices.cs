using System;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using System.IO;
using HandlebarsDotNet;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.DependencyInjection;

/*
 * https://github.com/TrackableEntities/EntityFrameworkCore.Scaffolding.Handlebars
 * dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=YashilDb;Persist Security Info=True;User ID=sa;Password=salam;MultipleActiveResultSets=True" Microsoft.EntityFrameworkCore.SqlServer -o Entities -c  YashilAppDbContext -f --context-dir Data 
 */
namespace Yashil.Core
{
    public class ScaffoldingDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
        {
            services.AddHandlebarsScaffolding(op =>
            {
                // Exclude some tables
                op.ExcludedTables = GetExcludedTables();
            });
            var options = GetReverseEngineerOptions();
            services.AddHandlebarsScaffolding(options);
            services.AddSingleton<ICSharpEntityTypeGenerator, YashilCSharpEntityTypeGenerator>();
            var myHelper = (helperName: "my-helper",
                helperFunction: (Action<TextWriter, Dictionary<string, object>, object[]>) MyHbsHelper);

            // Add optional Handlebars helpers
            services.AddHandlebarsHelpers(myHelper);


            Handlebars.RegisterHelper("handleNewLines", (output, context, arguments) => { });
        }

        protected virtual ReverseEngineerOptions GetReverseEngineerOptions()
        {
            return ReverseEngineerOptions.EntitiesOnly;
        }

        protected virtual List<string> GetExcludedTables()
        {
            return new List<string> {"Schemas"};
        }

        void MyHbsHelper(TextWriter writer, Dictionary<string, object> context, object[] parameters)
        {
            writer.Write("// My Handlebars Helper");
        }
    }
}