using AutoMapper;
using DevSu.Core.Enums;
using DevSu.Core.Interfaces;
using DevSu.Core.Models;
using DevSu.Services.Dto;
using DevSu.Services.Interfaces;

namespace DevSu.Services.ServiceHandlers
{
    public class ReportService : IReportService
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;
        private readonly IGenericRepository<Cuenta> _cuentaRepository;
        private readonly IGenericRepository<Movimiento> _movimientoRepository;
        private readonly IMapper _mapper;

        public ReportService(IGenericRepository<Cliente> clienteRepository, IGenericRepository<Cuenta> cuentaRepository, IGenericRepository<Movimiento> movimientoRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _cuentaRepository = cuentaRepository;
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
        }

        public async Task<ReportDto> GetReport(int clienteId, DateTime startDate, DateTime endDate)
        {
            var cliente = await _clienteRepository.GetByIdAsync(clienteId);

            if (cliente == null)
            {
                throw new AppExceptionHandler($"Cliente con ID {clienteId} no encontrado.");
            }

            var cuentas = await _cuentaRepository.GetWhereAsync(c => c.ClienteId == clienteId);

            var report = new ReportDto();
            report.Cliente = _mapper.Map<ClienteDto>(cliente);

            foreach (var cuenta in cuentas)
            {
                startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
                endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

                var movimientos = await _movimientoRepository.GetWhereAsync(m =>
          m.CuentaId == cuenta.NumeroCuenta 
          &&  m.Fecha >= startDate && m.Fecha <= endDate
      );

                var cuentaReportDto = new CuentaReportDto
                {
                    NumeroCuenta = cuenta.NumeroCuenta,
                    TipoCuenta = cuenta.TipoCuenta,
                    Saldo = cuenta.SaldoInicial,
                    TotalDebitos = movimientos.Where(m => m.TipoMovimiento == TipoMovimiento.Debito).Sum(m => m.Valor),
                    TotalCreditos = movimientos.Where(m => m.TipoMovimiento == TipoMovimiento.Credito).Sum(m => m.Valor),
                };

                report.Cuentas.Add(cuentaReportDto);
            }

            return report;
        }
    }
}
