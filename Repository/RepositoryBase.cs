using Core.Data;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public MiniProjetContext _context { get; set; }
        public readonly ILogger _logger;
        public RepositoryBase(MiniProjetContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// find entities by condition
        /// </summary>
        /// <param name="expression">expression provided for the search operation</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<T?> FindOneByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T?> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
           return await Task.Run(() => _context.Set<T>().Add(entity).Entity);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            return await Task.Run(() => _context.Set<T>().Update(entity).Entity);
        }
        public async Task DeleteAsync(T entity)
        {
           await Task.Run(() => _context.Set<T>().Remove(entity));   
        }
    }
}
