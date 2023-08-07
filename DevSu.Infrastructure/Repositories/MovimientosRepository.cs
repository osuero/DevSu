using DevSu.Core.Interfaces;
using DevSu.Core.Models;
using DevSu.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DevSu.Core.ModelDto;

namespace DevSu.Infrastructure.Repositories
{
    public class MovimientosRepository: IMovimientosRepository
    {
        private readonly DefaultDbContext _context;


        public MovimientosRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task Create(Movimiento entity)
        {
            entity.Fecha = DateTime.UtcNow;
            _context.Movimientos.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movimiento entity)
        {            
            _context.Movimientos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Movimientos.FindAsync(id);
            if (entity == null)
            {
                throw new NullReferenceException($"Entity not found with id {id}");
            }

            _context.Movimientos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movimiento>> GetWhereAsync(Expression<Func<Movimiento, bool>> predicate)
        {
            return await _context.Movimientos.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Movimiento>> GetAll()
        {
            return await _context.Movimientos.ToListAsync();
        }

        public async Task<Movimiento> GetById(int id)
        {
            return await _context.Movimientos.FindAsync(id);
        }
        public async Task<List<MovimientosResult>> GetMovimientosByDateAndUser(MovimientoQueryParameters parameters)
        {
            // Normalize date ranges to include the entire day
            DateTime startOfDay = parameters.StartDate.Date;
            DateTime endOfDay = parameters.EndDate.Date.AddTicks(TimeSpan.TicksPerDay - 1); // last moment of the day

            var movimientos = await (from m in _context.Movimientos
                                     join c in _context.Cuentas on m.CuentaId equals c.NumeroCuenta
                                     join cl in _context.Clientes on c.ClienteId equals cl.Id
                                     where c.ClienteId == parameters.ClientId &&
                                           m.Fecha >= startOfDay &&
                                           m.Fecha <= endOfDay
                                     select new MovimientosResult
                                     {
                                         Fecha = m.Fecha.ToShortDateString(),
                                         Cliente = cl.Nombres,
                                         NumeroCuenta = c.NumeroCuenta.ToString(),
                                         Tipo = c.TipoCuenta.ToString(),
                                         SaldoInicial = c.SaldoInicial,
                                         Estado = c.Estado,
                                         Movimiento = m.Valor,
                                         SaldoDisponible = c.SaldoDisponible
                                     }).ToListAsync();

            return movimientos;
        }

    }
}
