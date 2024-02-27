using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAll();

        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);

        Task<T?> FindOneByCondition(Expression<Func<T, bool>> expression);

        Task<T?> FindById(int id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);
    }
}
