using MediatR;


namespace APIDemo.Api.Data
{
    public class UpdatePersona
    {
        public sealed record Command : IRequest
        {
            public int Id { get; set; }

            public string Nombre { get; set; } = string.Empty;

            public string Apellido { get; set; } = string.Empty;
        }

        internal sealed class Handler : IRequestHandler<Command>
        {
            private readonly PersonaDbContext _dbContext;

            public Handler(PersonaDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var persona = _dbContext.Persona.FirstOrDefault(p => p.Id == request.Id);

                if (persona is null)
                {
                    throw new ApplicationException("Persona not found");
                }

                persona.Nombre = request.Nombre;
                persona.Apellido = request.Apellido;

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
