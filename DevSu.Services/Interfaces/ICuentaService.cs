using DevSu.Services.Dto;

namespace DevSu.Services.Interfaces
{
    public interface ICuentaService
    {
        Task<IEnumerable<CuentaDto>> GetAllAsync();
        Task<CuentaDto> GetByIdAsync(int id);
        Task CreateAsync(CuentaCreateDto dto);
        Task UpdateAsync(CuentaDto dto);
        Task DeleteAsync(int id);
    }
}
