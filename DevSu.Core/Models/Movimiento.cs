using DevSu.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace DevSu.Core.Models
{
    public class Movimiento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TipoMovimiento TipoMovimiento { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a cero.")]
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }

        [Required]
        public Cuenta Cuenta { get; set; }

        [Required]
        public int CuentaId { get; set; }
    }
}
