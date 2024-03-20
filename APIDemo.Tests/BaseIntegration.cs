using MediatR;
using Microsoft.Extensions.DependencyInjection;
using APIDemo.Api;

namespace APIDemo.Tests
{
    public abstract class BaseIntegration : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
    {
        private readonly IServiceScope _scope;
        protected readonly ISender Sender;
        protected readonly PersonaDbContext DbContext;

        protected BaseIntegration(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            DbContext = _scope.ServiceProvider.GetRequiredService<PersonaDbContext>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
            DbContext?.Dispose();
        }
    }
}
