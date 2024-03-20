using APIDemo.Api.Data;

namespace APIDemo.Api.Services
{
    public interface IPersonaService
    {
        Task AddAsync(Persona persona);
        Task<List<Persona>> GetAsync();
        Task<Persona?> GetAsync(int id);
        Task<bool> UpdateAsync(Persona persona);
    }
}