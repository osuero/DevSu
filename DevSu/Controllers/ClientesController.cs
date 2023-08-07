using DevSu.Services.Dto;
using DevSu.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DevSu.Services.ServiceHandlers;
using DevSu.Services.ServiceEntities;

namespace DevSu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var clientes = await _clienteService.GetAllAsync();
                return Ok(clientes);

            } catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error on get all: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try 
            { 
                var cliente = await _clienteService.GetByIdAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            } catch (AppExceptionHandler ex) 
            {
                return StatusCode(500, $"Internal server error on search by Id: {ex.Message}"); 
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteCreateDto clienteDto)
        {
            try
            {
                await _clienteService.CreateAsync(clienteDto);
                return Ok();
            }
            catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error on post: {ex.Message}");
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteDto clienteDto)
        {
            try
            {
                await _clienteService.UpdateAsync(clienteDto);
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
                await _clienteService.DeleteAsync(id);
                return Ok();
            } 
            catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error on delete: {ex.Message}");
            }

        }
    }

}
