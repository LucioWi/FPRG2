using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repository
{
    public class EnviosRepository : IEnvioRepository
    {
        private readonly EnviosDBContext _context;

        public EnviosRepository(EnviosDBContext context)
        {
            _context = context;
        }

        public async Task<List<Envio>> GetByDniAsync(string dniCliente)
        {
            return await _context.TEnvios
                .AsNoTracking()
                .Where(e => e.DniCliente == dniCliente)
                .ToListAsync();
        }
        public async Task<Envio> CreateAsync(Envio envio)
        {
            _context.TEnvios.Add(envio);
            await _context.SaveChangesAsync();
            return envio;
        }
    }
}
