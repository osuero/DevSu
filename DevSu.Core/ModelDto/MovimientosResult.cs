using System.Text.Json.Serialization;
namespace DevSu.Core.ModelDto
{
    public class MovimientosResult
    {
        [JsonPropertyName("Fecha")]
        public string Fecha { get; set; }

        [JsonPropertyName("Cliente")]
        public string Cliente { get; set; }

        [JsonPropertyName("Numero Cuenta")]
        public string NumeroCuenta { get; set;}

        [JsonPropertyName("Tipo")]
        public string Tipo { get; set; }

        [JsonPropertyName("Saldo Inicial")]
        public decimal SaldoInicial { get; set; }

        [JsonPropertyName("Estado")]
        public bool Estado { get; set; }

        [JsonPropertyName("Movimiento")]
        public decimal Movimiento { get; set; }

        [JsonPropertyName("Saldo Disponible")]
        public decimal SaldoDisponible { get; set; }
    }
}
