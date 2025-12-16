using WebApi.DTOs;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services
{
    public class EnvioService
    {
        private readonly IEnvioRepository _envioRepository;

        public EnvioService(IEnvioRepository envioRepository)
        {
            _envioRepository = envioRepository;
        }

        public async Task<List<EnvioDTO>> GetEnviosByDniAsync(string dniCliente)
        {
            if (string.IsNullOrWhiteSpace(dniCliente))
                return new List<EnvioDTO>();

            var envios = await _envioRepository.GetByDniAsync(dniCliente);

            return envios.Select(e => new EnvioDTO
            {
                Id = e.Id,
                Fecha = e.Fecha,
                DniCliente = e.DniCliente,
                Direccion = e.Direccion,
                Estado = e.Estado
            }).ToList();
        }
        public async Task<EnvioDTO?> CreateEnvioAsync(EnvioCreateDTO dto)
        {
            if (dto == null)
                return null;

            var envio = new Envio
            {
                Fecha = dto.Fecha,
                DniCliente = dto.DniCliente,
                Direccion = dto.Direccion,
                Estado = "Iniciado",
                PalabraSecreta = dto.PalabraSecreta,
                TDetallesEnvios = dto.TDetallesEnvios
            };

            var creado = await _envioRepository.CreateAsync(envio);

            return new EnvioDTO
            {
                Id = creado.Id,
                Fecha = creado.Fecha,
                DniCliente = creado.DniCliente,
                Direccion = creado.Direccion,
                Estado = creado.Estado
            };
        }
    }
}
