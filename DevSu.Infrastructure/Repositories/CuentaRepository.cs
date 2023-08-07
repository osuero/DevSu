using DevSu.Core.Interfaces;
using DevSu.Core.Models;
using DevSu.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevSu.Infrastructure.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly DefaultDbContext _context;

        public CuentaRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cuenta>> GetAllAsync()
        {
            return await _context.Cuentas.ToListAsync();
        }

        public async Task<Cuenta> GetByIdAsync(int id)
        {
            var result = await _context.Cuentas.FindAsync(id);
            return result;
        }

        public async Task Create(Cuenta entity)
        {
            entity.SaldoDisponible = entity.SaldoInicial;
            entity.FechaActualizacion = DateTime.UtcNow;
            entity.FechaCreacion = DateTime.UtcNow;

            await _context.Cuentas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cuenta entity)
        {
            entity.FechaActualizacion = DateTime.UtcNow;
            _context.Cuentas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Cuentas.FindAsync(id);
            if (entity == null)
            {
                throw new NullReferenceException($"Entity not found with id {id}");
            }

            _context.Cuentas.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cuenta>> GetWhereAsync(Expression<Func<Cuenta, bool>> predicate)
        {
            return await _context.Cuentas.Where(predicate).ToListAsync();
        }
    }
}
