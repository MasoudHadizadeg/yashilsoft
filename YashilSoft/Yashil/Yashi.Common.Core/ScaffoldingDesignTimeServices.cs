using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

/*
 * dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=YashilDb;Persist Security Info=True;User ID=sa;Password=salam;MultipleActiveResultSets=True" Microsoft.EntityFrameworkCore.SqlServer -o Entities -c  YashilAppDbContext -f --context-dir Data --schema dbo
 */
namespace Yashil.Common.Core
{
    public abstract class ScaffoldingDesignTimeServices : IDesignTimeServices
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
        }

        protected virtual ReverseEngineerOptions GetReverseEngineerOptions()
        {
            return ReverseEngineerOptions.EntitiesOnly;
        }

        protected virtual List<string> GetExcludedTables()
        {
            return new List<string> { };

        }

    }
}
