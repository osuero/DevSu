using DevSu.Core.Interfaces;
using DevSu.Core.Models;
using DevSu.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevSu.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DefaultDbContext _context;

        public ClienteRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task CreateAsync(Cliente entity)
        {
            await _context.Clientes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente entity)
        {
            _context.Clientes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            if (entity == null)
            {
                throw new NullReferenceException($"Entity not found with id {id}");
            }

            _context.Clientes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> GetWhere(Expression<Func<Cliente, bool>> predicate)
        {
            return await _context.Clientes.Where(predicate).ToListAsync();
        }
    }
}

