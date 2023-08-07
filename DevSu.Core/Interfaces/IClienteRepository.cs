using DevSu.Core.Models;
using System.Linq.Expressions;

namespace DevSu.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetById(int id);
        Task CreateAsync(Cliente entity);
        Task Update(Cliente entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Cliente>> GetWhere(Expression<Func<Cliente, bool>> predicate);
    }
}
