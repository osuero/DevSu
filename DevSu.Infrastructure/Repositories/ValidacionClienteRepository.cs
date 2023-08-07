using DevSu.Core.Interfaces;
using DevSu.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevSu.Infrastructure.Repositories
{
    public class ValidacionClienteRepository : IValidacionClienteRepository
    {
        private readonly DefaultDbContext _context;

        public ValidacionClienteRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DoesClientExist(string names, string phoneNumber)
        {
            return await _context.Clientes.Where(x => x.Nombres == names && x.Telefono == phoneNumber).AnyAsync();
        }
    }
}

