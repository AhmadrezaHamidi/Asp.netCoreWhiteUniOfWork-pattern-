using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TamsaApi.Core.IRepositories;
using TamsaApi.Domain.BaseDomain;
using tTamsaApi.Domain.BaseDomain;

namespace PocketBook.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepositories<T> where T : BaseDomainEntity
    {
        protected TamsaApisaContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(TamsaApisaContext context, ILogger logger)
        {
            _context = context;
            this.dbSet = context.Set<T>();
            _logger = logger;
        }  

        public virtual async Task<bool> Add(T entity)
        {
           await dbSet.AddAsync(entity);
           return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
           return await dbSet.ToListAsync();
        }

        public virtual Task<bool> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<T> GetById(string id)
        {
              return await dbSet.FindAsync(id);
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}