using APIDemo.Api.Data;

namespace APIDemo.Tests
{
    public class PersonaTests  : BaseIntegration
    {
        public PersonaTests(IntegrationTestWebAppFactory factory)
        : base(factory)
        {
        }

        [Fact]
        public async Task CreatePersona_Test()
        {
            // Arrange
            var command = new CreatePersona.Command
            {
                Nombre = "Alex",
                Apellido = "Morales"
            };

            // Act
            var personaId = await Sender.Send(command);

            // Assert
            var persona = DbContext.Persona.FirstOrDefault(p => p.Id == personaId);

            Assert.NotNull(persona);
        }

        [Fact]
        public async Task GetPersonaExists()
        {
            // Arrange
            var personaId = await CreatePersona();
            var query = new GetPersona.Query { Id = personaId };

            // Act
            var personaResponse = await Sender.Send(query);

            // Assert
            Assert.NotNull(personaResponse);
        }

        [Fact]
        public async Task GetPersonIsNull()
        {
            // Arrange
            var query = new GetPersona.Query { Id = 0 };

            // Act
            Task Action() => Sender.Send(query);

            // Assert
            await Assert.ThrowsAsync<ApplicationException>(Action);
        }

        [Fact]
        public async Task UpdateWhenPersonExists()
        {
            // Arrange
            var personaId = await CreatePersona();
            var command = new UpdatePersona.Command
            {
                Id = personaId,
                Nombre = "Alex",
                Apellido = "Morales"
            };

            // Act
            await Sender.Send(command);

            // Assert
        }

        [Fact]
        public async Task UpdateWhenPersonaIsNull()
        {
            // Arrange
            var command = new UpdatePersona.Command
            {
                Id = 0,
                Nombre = "Alex",
                Apellido = "Morales"
            };

            // Act
            Task Action() => Sender.Send(command);

            // Assert
            await Assert.ThrowsAsync<ApplicationException>(Action);
        }

        //[Fact]
        //public async Task Delete_ShouldDeleteProduct_WhenProductExists()
        //{
        //    // Arrange
        //    var productId = await CreateProduct();
        //    var command = new DeleteProduct.Command { Id = productId };

        //    // Act
        //    await Sender.Send(command);

        //    // Assert
        //    var product = DbContext.Products.FirstOrDefault(p => p.Id == productId);

        //    Assert.Null(product);
        //}

        //[Fact]
        //public async Task Delete_ShouldThrow_WhenProductIsNull()
        //{
        //    // Arrange
        //    var command = new DeleteProduct.Command { Id = Guid.NewGuid() };

        //    // Act
        //    Task Action() => Sender.Send(command);

        //    // Assert
        //    await Assert.ThrowsAsync<ApplicationException>(Action);
        //}

        private async Task<int> CreatePersona()
        {
            var command = new CreatePersona.Command
            {
                Nombre = "Alex",
                Apellido = "Morales"
            };

            var personaId = await Sender.Send(command);

            return personaId;
        }

        //[Fact]
        //public async Task AddPersona_Test()
        //{
        //    // Arrange

        //    var container = new SqlEdgeBuilder()
        //                .WithImage("mcr.microsoft.com/azure-sql-edge")
        //                .Build();

        //    await container.StartAsync();

        //    var context = new PersonaDbContext(new DbContextOptionsBuilder<PersonaDbContext>()
        //                                    .UseSqlServer(container.GetConnectionString())
        //                                    .Options
        //    );

        //    await context.Database.EnsureCreatedAsync();

        //    var service = new PersonaService(context);

        //    // Act
        //    await service.AddAsync(new Persona()
        //    {
        //        Nombre = "Alex",
        //        Apellido = "Morales"
        //    });


        //    // Assert
        //    var dbPersona = await context.Persona.ToListAsync();
        //    Assert.Single(dbPersona);
        //    Assert.Equal("Alex", dbPersona[0].Nombre);
        //    Assert.Equal("Morales", dbPersona[0].Apellido);

        //    await container.DisposeAsync();
        //}

        //[Fact]
        //public async Task GetTodo_Test()
        //{
        //    // Arrange

        //    var container = new SqlEdgeBuilder()
        //                .WithImage("mcr.microsoft.com/azure-sql-edge")
        //                .Build();

        //    await container.StartAsync();

        //    var context = new PersonaDbContext(new DbContextOptionsBuilder<PersonaDbContext>()
        //                                    .UseSqlServer(container.GetConnectionString())
        //                                    .Options
        //    );

        //    await context.Database.EnsureCreatedAsync();

        //    var service = new PersonaService(context);

        //    await context.Persona.AddAsync(new Persona()
        //    {
        //        Nombre = "Alex",
        //        Apellido = "Morales",
        //    });

        //    await context.Persona.AddAsync(new Persona()
        //    {
        //        Nombre = "Monica",
        //        Apellido = "Sanchez",
        //    });

        //    await context.SaveChangesAsync();

        //    // Act
        //    var list = await service.GetAsync();

        //    // Assert
        //    Assert.Equal(2, list.Count);
        //    Assert.Equal("Test New Todo", list[0].Nombre);
        //    Assert.Equal("Test New Todo", list[0].Apellido);
        //    Assert.Equal("Test New Todo 2", list[1].Nombre);
        //    Assert.Equal("Test New Todo", list[0].Apellido);

        //    await container.DisposeAsync();
        //}
    }    
}
