using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sportal.Services
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<TEntity> GetRepositoryInstance<TEntity>() where TEntity : class;
        Task<int> SaveAsync();
    }
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
