using AutoMapper;
using DevSu.Core.Enums;
using DevSu.Core.Interfaces;
using DevSu.Core.Models;
using DevSu.Services.Dto;
using DevSu.Services.Interfaces;

namespace DevSu.Services.ServiceHandlers
{
    public class CalculoMovimientosService : ICalculoMovimientosService
    {
        private readonly IMapper _mapper;
        private const decimal MAX_WITHDRAWAL_LIMIT = 1000;
        private readonly IMovimientosRepository _movimientoRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public CalculoMovimientosService(IMapper mapper, IMovimientosRepository movimientoRepository, ICuentaRepository cuentaRepository)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
        }

        public async Task<Movimiento> CalculateMovement(MovimientoCreateDto movimientoDto)
        {
            var cuenta = (await _cuentaRepository.GetWhereAsync(x => x.NumeroCuenta == movimientoDto.CuentaId)).FirstOrDefault();

            if (movimientoDto.TipoMovimiento == TipoMovimiento.Debito)
            {
                if (cuenta.SaldoInicial < movimientoDto.Valor)
                {
                    throw new AppExceptionHandler("Saldo no disponible.");
                }

                var todayMovimientos = await _movimientoRepository.GetWhereAsync(m => m.Fecha >= DateTime.Today && m.CuentaId == movimientoDto.CuentaId);
                var todayWithdrawalSum = todayMovimientos.Where(m => m.TipoMovimiento == TipoMovimiento.Debito).Sum(m => m.Valor);
                if (todayWithdrawalSum + movimientoDto.Valor > MAX_WITHDRAWAL_LIMIT)
                {
                    throw new AppExceptionHandler("Cupo diario Excedido.");
                }

                cuenta.SaldoDisponible -= movimientoDto.Valor;
            }
            else 
            {
                cuenta.SaldoDisponible += movimientoDto.Valor;
            }

            var movement = _mapper.Map<Movimiento>(movimientoDto);
            movement.Saldo = cuenta.SaldoDisponible;
           
            await _cuentaRepository.Update(cuenta);
            
            return movement;
        }
    }

}
