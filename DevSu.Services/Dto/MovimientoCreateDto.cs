using DevSu.Core.Enums;

namespace DevSu.Services.Dto
{
    public class MovimientoCreateDto
    {
        public TipoMovimiento TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public int CuentaId { get; set; }
    }
}
