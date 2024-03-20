using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using APIDemo.Api.Contracts;
using APIDemo.Api.Services;

namespace APIDemo.Api.Data
{
    public class GetPersona
    {
        public sealed record Query : IRequest<PersonaResponse>
        {
            public int Id { get; set; }
        }

        internal sealed class Handler : IRequestHandler<Query, PersonaResponse>
        {
            private readonly PersonaDbContext _dbContext;

            public Handler(PersonaDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<PersonaResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var persona = await _dbContext.Persona.AsNoTracking().FirstOrDefaultAsync(p => p.Id == request.Id);

                if (persona is null)
                {
                    throw new ApplicationException("persona not found");
                }

                return persona.Adapt<PersonaResponse>();
            }
        }
    }
}
