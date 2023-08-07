using AutoMapper;
using DevSu.Core.Interfaces;
using DevSu.Core.ModelDto;
using DevSu.Core.Models;
using DevSu.Services.Dto;
using DevSu.Services.Interfaces;

namespace DevSu.Services.ServiceEntities
{
    public class MovimientoService : IMovimientosService
    {
        private readonly ICalculoMovimientosService _movementCalculationService;
        private readonly IMovimientosRepository _movimientoRepository;
        private readonly IMapper _mapper;
        public MovimientoService(IMovimientosRepository movimientoRepository, IMapper mapper, ICalculoMovimientosService movementCalculationService)
        {
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
            _movementCalculationService = movementCalculationService;
        }

        public async Task CreateAsync(MovimientoCreateDto dto)
        {
            var newMovementDto = await _movementCalculationService.CalculateMovement(dto);
        
            await _movimientoRepository.Create(newMovementDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _movimientoRepository.Delete(id);
        }

        public async Task<IEnumerable<MovimientoDto>> GetAllAsync()
        {
            var movement = await _movimientoRepository.GetAll();
            return _mapper.Map<IEnumerable<MovimientoDto>>(movement);
        }

        public async Task<MovimientoDto> GetByIdAsync(int id)
        {
            var movement = await _movimientoRepository.GetById(id);
            return _mapper.Map<MovimientoDto>(movement);
        }

        public async Task UpdateAsync(MovimientoDto dto)
        {
            var movement = _mapper.Map<Movimiento>(dto);
            await _movimientoRepository.UpdateAsync(movement);
        }

        public async Task<List<MovimientosResult>> GetMovimientosByDateAndUserAsync(MovimientoQueryParameters parameters)
        {
            var movimientos = await _movimientoRepository.GetMovimientosByDateAndUser(parameters);
            return movimientos;
        }
    }
}
