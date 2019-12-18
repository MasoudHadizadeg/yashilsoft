using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Yashil.Common.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        int Commit();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}