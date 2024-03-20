using APIDemo.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Api.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly PersonaDbContext _dbContext;

        public PersonaService(PersonaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<List<Persona>> GetAsync()
        => _dbContext.Persona.ToListAsync();

        public Task<Persona?> GetAsync(int id)
            => _dbContext.Persona.FirstOrDefaultAsync(persona => persona.Id == id);

        public async Task AddAsync(Persona persona)
        {
            await _dbContext.Persona.AddAsync(persona);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Persona persona)
        {
            var dbPersona = await _dbContext.Persona.FindAsync(persona.Id);

            if (dbPersona is null) return false;

            dbPersona.Nombre = persona.Nombre;
            dbPersona.Apellido = persona.Apellido;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
