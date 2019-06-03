using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sportal.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        private DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();

        }
        public void Add(TEntity tEntity)
        {
            _dbContext.Set<TEntity>().Add(tEntity);
        }

        public void AddRange(IEnumerable<TEntity> tEntity)
        {
            _dbContext.Set<TEntity>().AddRange(tEntity);
        }       

        public IQueryable<TEntity> FindAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public Task<TEntity> FindById(string id)
        {
            return _dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity tEntity)
        {
            _dbContext.Set<TEntity>().Remove(tEntity);
        }

        public void RemoveRange(IEnumerable<TEntity> tEntity)
        {
            _dbContext.Set<TEntity>().RemoveRange(tEntity);
        }
    }
}
