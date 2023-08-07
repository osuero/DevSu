using DevSu.Core.Enums;

namespace DevSu.Services.Dto
{
    public class CuentaReportDto
    {
        public int NumeroCuenta { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public decimal Saldo { get; set; }
        public decimal TotalDebitos { get; set; }
        public decimal TotalCreditos { get; set; }
    }
}
