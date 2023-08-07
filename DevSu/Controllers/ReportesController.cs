using DevSu.Services.Dto;
using DevSu.Services.Interfaces;
using DevSu.Services.ServiceHandlers;
using Microsoft.AspNetCore.Mvc;

namespace DevSu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportesController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportesController(IReportService reportService) 
        {
            _reportService = reportService;
        }

        [HttpPost("GetReport")]
        public async Task<ActionResult<ReportDto>> GetReport([FromBody] ReportRequestDto request)
        {
            try
            {
                var report = await _reportService.GetReport(request.ClienteId, request.StartDate, request.EndDate);
                return Ok(report);
            }
            catch (AppExceptionHandler ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
