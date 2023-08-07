using System.Linq.Expressions;

namespace DevSu.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        Task Create(T entity);
        Task UpdateAsync(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
    }
}
