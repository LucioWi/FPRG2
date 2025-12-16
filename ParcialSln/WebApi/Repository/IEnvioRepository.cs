using WebApi.Models;

namespace WebApi.Repository
{
    public interface IEnvioRepository
    {
        Task<List<Envio>> GetByDniAsync(string dniCliente);
        Task<Envio> CreateAsync(Envio envio);
    }
}
