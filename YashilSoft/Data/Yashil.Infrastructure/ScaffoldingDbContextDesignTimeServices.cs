using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using Yashil.Common.Core;

namespace Yashil.Infrastructure
{
    class ScaffoldingDbContextDesignTimeServices : ScaffoldingDesignTimeServices
    {
        protected override List<string> GetExcludedTables()
        {
            return new List<string> { "TableDesc", "Schemas" };
        }

        protected override ReverseEngineerOptions GetReverseEngineerOptions()
        {
            return ReverseEngineerOptions.DbContextOnly;
        }
    }
}
