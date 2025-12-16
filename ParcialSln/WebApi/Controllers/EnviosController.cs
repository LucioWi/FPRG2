using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly EnvioService _envioService;

        public EnviosController(EnvioService envioService)
        {
            _envioService = envioService;
        }

        // GET: api/envios/dni/{dni}
        [HttpGet("dni/{dni}")]
        public async Task<IActionResult> GetByDni(string dni)
        {
            // Validación 1: obligatorio
            if (string.IsNullOrWhiteSpace(dni))
                return BadRequest("El DNI es obligatorio.");

            // Validación 2: solo números
            if (!dni.All(char.IsDigit))
                return BadRequest("El DNI debe contener solo números.");

            var result = await _envioService.GetEnviosByDniAsync(dni);

            // Validación 3: sin resultados
            if (result == null || !result.Any())
                return NotFound("No se encontraron envíos para el DNI ingresado.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnvioCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos.");

            var result = await _envioService.CreateEnvioAsync(dto);

            if (result == null)
                return BadRequest("No se pudo crear el envío.");

            return CreatedAtAction(nameof(Post), result);
        }
    }
}
