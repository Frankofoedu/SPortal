using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportal.Services
{
   public interface IRepository<TEntity> where TEntity:class
   {
        
        IQueryable<TEntity> FindAll();
       Task<TEntity> FindById(string id);

        void Add(TEntity tEntity);
        void AddRange(IEnumerable<TEntity> tEntity);

        void Remove(TEntity tEntity);
        void RemoveRange(IEnumerable<TEntity> tEntity);

    }
}
