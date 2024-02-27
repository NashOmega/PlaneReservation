using Core.Data;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public MiniProjetContext _context { get; set; }
        public RepositoryBase(MiniProjetContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// find entities by condition
        /// </summary>
        /// <param name="expression">expression provided for the search operation</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<T?> FindOneByCondition(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<T?> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Create(T entity)
        {
            var dbEntity = _context.Set<T>().Add(entity).Entity;
            await _context.SaveChangesAsync();
            return dbEntity;
        }
        public async Task<T> Update(T entity)
        {
            var dbEntity = _context.Set<T>().Update(entity).Entity;
            await _context.SaveChangesAsync();
            return dbEntity;
        }
        public async Task Delete(T entity)
        {
           _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
