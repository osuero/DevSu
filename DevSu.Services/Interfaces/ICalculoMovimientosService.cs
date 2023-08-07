using DevSu.Core.Models;
using DevSu.Services.Dto;

namespace DevSu.Services.Interfaces
{
    public interface ICalculoMovimientosService
    {
        Task<Movimiento> CalculateMovement(MovimientoCreateDto movimientoDto);
    }
}
