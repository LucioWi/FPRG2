namespace WebApi.DTOs
{
    public class EnvioDTO
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public required string DniCliente { get; set; }

        public required string Direccion { get; set; }

        public required string Estado { get; set; }
    }
}
