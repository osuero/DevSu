using AutoMapper;
using DevSu.Core.Interfaces;
using DevSu.Core.Models;
using DevSu.Services.Dto;
using DevSu.Services.Interfaces;
using DevSu.Services.ServiceHandlers;

namespace DevSu.Services.ServiceEntities
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clientRepository;
        private readonly IValidacionClienteService _validacionClienteService;
        private readonly IMapper _mapper;
        public ClienteService(IValidacionClienteService validacionClienteService,IClienteRepository  clientRepository, IMapper mapper) 
        {
            _validacionClienteService = validacionClienteService;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ClienteCreateDto dto)
        {
            bool clientExists = await _validacionClienteService.DoesClientExist(dto.Nombres, dto.Telefono);
            if (clientExists)
            {
                throw new AppExceptionHandler("El cliente ya existe.");
            }

            var client = _mapper.Map<Cliente>(dto);
            await _clientRepository.CreateAsync(client);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var client = await _clientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDto>>(client);
        }

        public async Task<ClienteDto> GetByIdAsync(int id)
        {
            var entity = await _clientRepository.GetById(id);
            return _mapper.Map<ClienteDto>(entity);
        }

        public async Task UpdateAsync(ClienteDto dto)
        {
            var existingClient = await _clientRepository.GetById(dto.Id);
            if (existingClient.Nombres != dto.Nombres || existingClient.Telefono != dto.Telefono)
            {
                bool clientExists = await _validacionClienteService.DoesClientExist(dto.Nombres, dto.Telefono);
                if (clientExists)
                {
                    throw new AppExceptionHandler("No puede ser actualizado porque el cliente ya existe.");
                }
            }

            var client = _mapper.Map<Cliente>(dto);
            await _clientRepository.Update(client);
        }
    }
}
