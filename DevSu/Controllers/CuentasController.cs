using DevSu.Services.Dto;
using DevSu.Services.Interfaces;
using DevSu.Services.ServiceHandlers;
using Microsoft.AspNetCore.Mvc;

namespace DevSu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        public CuentasController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try 
            {             
                var cuenta = await _cuentaService.GetAllAsync();
                return Ok(cuenta);
            }
           catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error on get all: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            try 
            {
                var cuenta = await _cuentaService.GetByIdAsync(id);
                if (cuenta == null)
                {
                    return NotFound();
                }
                return Ok(cuenta);
            } 
            catch (AppExceptionHandler ex) 
            {
                return StatusCode(500, $"Internal server error on get By Id: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CuentaCreateDto cuentaDto)
        {
            try { 
                await _cuentaService.CreateAsync(cuentaDto);
                return Ok();
            } 
            catch (AppExceptionHandler ex) 
            {
                return StatusCode(500, $"Internal server error on create: {ex.Message}");
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CuentaDto cuentaDto)
        {
            try
            {
                await _cuentaService.UpdateAsync(cuentaDto);
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
                await _cuentaService.DeleteAsync(id);
                return Ok();
            }
            catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error on delete: {ex.Message}");
            }

        }
    }
}
