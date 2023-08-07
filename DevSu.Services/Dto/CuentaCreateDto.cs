using DevSu.Core.Enums;

namespace DevSu.Services.Dto
{
    public class CuentaCreateDto
    {
        public int NumeroCuenta { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public string ClienteNombre { get; set; }
    }
}
