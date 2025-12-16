using System.Text.Json.Serialization;
using WebApi.Models;

namespace WebApi.DTOs
{
    public class DetalleEnvioCreateDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public required string Comentario { get; set; }
    }
}
