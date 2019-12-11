using Microsoft.EntityFrameworkCore.Design;
using Yashil.Core;

namespace Yashil.Infrastructure
{
    class ScaffoldingDbContextDesignTimeServices : ScaffoldingDesignTimeServices
    {
        protected override ReverseEngineerOptions GetReverseEngineerOptions()
        {
            return ReverseEngineerOptions.DbContextOnly;
        }
    }
}