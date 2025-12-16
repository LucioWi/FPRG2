using WebApi.Models;

namespace WebApi.DTOs
{
    public class EnvioCreateDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public required string DniCliente { get; set; }
        public required string Direccion { get; set; }
        public required string PalabraSecreta { get; set; }
        public virtual ICollection<DetallesEnvio> TDetallesEnvios { get; set; } = new List<DetallesEnvio>();
    }
}
