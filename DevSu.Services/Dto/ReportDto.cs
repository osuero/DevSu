namespace DevSu.Services.Dto
{
    public class ReportDto
    {
        public ClienteDto Cliente { get; set; }
        public List<CuentaReportDto> Cuentas { get; set; } = new List<CuentaReportDto>();
    }
}
