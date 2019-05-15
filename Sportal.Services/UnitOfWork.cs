using SPortal.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sportal.Services.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext: ApplicationDbContext, IDisposable
    {
        
        public TContext _dbContext
        {
            get;
        }

        public UnitOfWork(TContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IRepository<TEntity> GetRepositoryInstance<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_dbContext);
        }


        public void Dispose()
        {
             _dbContext.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
