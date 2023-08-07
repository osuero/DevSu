using DevSu.Services.Dto;

namespace DevSu.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportDto> GetReport(int clienteId, DateTime startDate, DateTime endDate);
    }
}
