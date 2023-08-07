using DevSu.Core.ModelDto;
using DevSu.Services.Dto;
using DevSu.Services.Interfaces;
using DevSu.Services.ServiceHandlers;
using Microsoft.AspNetCore.Mvc;

namespace DevSu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientosService _movimientoService;
        public MovimientosController(IMovimientosService movimientosService)
        {
            _movimientoService = movimientosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var movimientos = await _movimientoService.GetAllAsync();
                return Ok(movimientos);
            }
            catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error on getAll: {ex.Message}");
            }
        }

        [HttpPost("movimientosByUserDate")]
        public async Task<IActionResult> GetMovimientosByDateAndUserAsync([FromBody] MovimientoQueryParameters parameters)
        {
            try
            {
                var movimientos = await _movimientoService.GetMovimientosByDateAndUserAsync(parameters);
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while fetching the data.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cuenta = await _movimientoService.GetByIdAsync(id);
                if (cuenta == null)
                {
                    return NotFound();
                }
                return Ok(cuenta);
            }
            catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error on get by Id: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovimientoCreateDto movimientoDto)
        {
            try {
                await _movimientoService.CreateAsync(movimientoDto);
                return Ok();
            } 
            catch (AppExceptionHandler ex)
            { return StatusCode(500, $"Internal server error on get by Id: {ex.Message}"); 
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MovimientoDto movimientoDto)
        {
            try
            {
                await _movimientoService.UpdateAsync(movimientoDto);
                return Ok();
            }
            catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error on update: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {          
                await _movimientoService.DeleteAsync(id);
                return Ok();

            }
            catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error on delete: {ex.Message}");
            }
        }
    }
}
