using DevSu.Core.Models;
using System.Linq.Expressions;

namespace DevSu.Core.Interfaces
{
    public interface ICuentaRepository
    {
        Task<IEnumerable<Cuenta>> GetAllAsync();
        Task<Cuenta> GetByIdAsync(int id);
        Task Create(Cuenta entity);
        Task Update(Cuenta entity);
        Task Delete(int id);
        Task<IEnumerable<Cuenta>> GetWhereAsync(Expression<Func<Cuenta, bool>> predicate);
    }
}
