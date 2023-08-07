using DevSu.Core.Interfaces;
using DevSu.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevSu.Infrastructure.Repositories
{
    public class ValidacionCuentaRepository : IValidacionCuentaRepository
    {
        private readonly DefaultDbContext _context;

        public ValidacionCuentaRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DoesAccountExist(int accountNumber)
        {
             return await _context.Cuentas.Where(x => x.NumeroCuenta == accountNumber).AnyAsync();
        }

        public async Task<bool> DoesClientNameExist(string clientName)
        {
           return await _context.Clientes.Where(x=> x.Nombres == clientName).AnyAsync();
        }
    }
}
