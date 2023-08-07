using DevSu.Services.Dto;

namespace DevSu.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto> GetByIdAsync(int id);
        Task CreateAsync(ClienteCreateDto dto);
        Task UpdateAsync(ClienteDto dto);
        Task DeleteAsync(int id);
    }
}
