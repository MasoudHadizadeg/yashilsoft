using System.Collections.Generic;
using Yashil.Common.Core;

namespace Yashil.Core
{
    public class ScaffoldingEntitiesDesignTimeServices : ScaffoldingDesignTimeServices
    {
        protected override List<string> GetExcludedTables()
        {
            return new List<string> { "TableDesc", "Schemas" };
        }
    }
}
