using Microsoft.EntityFrameworkCore;

namespace Yashil.Common.SharedKernel.Module
{
    public interface ICustomModelBuilder
    {
        void OnModelCreating(ModelBuilder modelBuilder);
    }
}
