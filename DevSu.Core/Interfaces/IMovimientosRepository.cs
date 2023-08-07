using DevSu.Core.ModelDto;
using DevSu.Core.Models;
using System.Linq.Expressions;

namespace DevSu.Core.Interfaces
{
    public interface IMovimientosRepository
    {
        Task<IEnumerable<Movimiento>> GetAll();
        Task<Movimiento> GetById(int id);
        Task Create(Movimiento entity);
        Task UpdateAsync(Movimiento entity);
        Task Delete(int id);
        Task<List<MovimientosResult>> GetMovimientosByDateAndUser(MovimientoQueryParameters parameters);
        Task<IEnumerable<Movimiento>> GetWhereAsync(Expression<Func<Movimiento, bool>> predicate);
    }
}
