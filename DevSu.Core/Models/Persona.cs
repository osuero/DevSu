using System.ComponentModel.DataAnnotations;

namespace DevSu.Core.Models
{
    public class Persona
    {
        [Required]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Telefono { get; set; }
    }
}
