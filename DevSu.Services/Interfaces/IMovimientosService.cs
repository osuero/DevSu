using DevSu.Core.ModelDto;
using DevSu.Services.Dto;
using System.Threading.Tasks;

namespace DevSu.Services.Interfaces
{
    public interface IMovimientosService
    {
        Task<IEnumerable<MovimientoDto>> GetAllAsync();
        Task<MovimientoDto> GetByIdAsync(int id);
        Task CreateAsync(MovimientoCreateDto dto);
        Task UpdateAsync(MovimientoDto dto);
        Task DeleteAsync(int id);
        Task<List<MovimientosResult>> GetMovimientosByDateAndUserAsync(MovimientoQueryParameters parameters);
    }
}
