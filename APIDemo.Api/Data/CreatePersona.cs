using MediatR;
using APIDemo.Api.Data;

namespace APIDemo.Api.Data
{
    public class CreatePersona
    {
        public sealed class Command : IRequest<int>
        {
            public string Nombre { get; set; } = string.Empty;

            public string Apellido { get; set; } = string.Empty;
        }

        internal sealed class Handler : IRequestHandler<Command, int>
        {
            private readonly PersonaDbContext _dbContext;

            public Handler(PersonaDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var persona = new Persona
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido
                };

                _dbContext.Add(persona);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return persona.Id;
            }
        }
    }
}
