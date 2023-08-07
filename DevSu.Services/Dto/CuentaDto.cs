using DevSu.Core.Enums;

namespace DevSu.Services.Dto
{
    public class CuentaDto
    {
        public int Id { get; set; }
        public int NumeroCuenta { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public decimal SaldoInicial { get; set; }
        public string Estado { get; set; }
        public string ClienteNombre { get; set; }
    }
}
