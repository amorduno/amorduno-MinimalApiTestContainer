using APIDemo.Api;
using APIDemo.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.MsSql;


namespace APIDemo.Tests.Fixture
{
    public class DockerWebApplicationFactoryFixture : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private MsSqlContainer _dbContainer;

        public int InitialPersona { get; } = 3;
        public DockerWebApplicationFactoryFixture()
        {
            //aqui creamos el contenedor
            _dbContainer = new MsSqlBuilder().Build();
        }

        //Aqui configuramos nuestra webapplication factory
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var connectionString = _dbContainer.GetConnectionString();
            base.ConfigureWebHost(builder);
            builder.ConfigureTestServices(service =>
            {
                service.RemoveAll(typeof(DbContextOptions<PersonaDbContext>));
                service.AddDbContext<PersonaDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();

            using (var scope = Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<PersonaDbContext>();

                await context.Database.EnsureCreatedAsync();

                await context.Persona.AddRangeAsync(DataFixture.GetPersonas(InitialPersona));
                await context.SaveChangesAsync();
            }
        }        

        public async Task DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }
    }
}
