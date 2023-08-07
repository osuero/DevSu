using System.ComponentModel.DataAnnotations;

namespace DevSu.Core.Models
{
    public class Cliente : Persona
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Cuenta> Cuentas { get; set; }
    }
}
