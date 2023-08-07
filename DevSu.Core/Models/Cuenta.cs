using System.ComponentModel.DataAnnotations;
using DevSu.Core.Enums;
namespace DevSu.Core.Models
{
    public class Cuenta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int NumeroCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public TipoCuenta TipoCuenta { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a cero.")]
        public decimal SaldoInicial { get; set; }
        public decimal SaldoDisponible{ get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; } 
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
