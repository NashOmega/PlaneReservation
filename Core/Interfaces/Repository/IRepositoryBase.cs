using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAllAsync();

        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        Task<T?> FindOneByConditionAsync(Expression<Func<T, bool>> expression);

        Task<T?> FindByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
