using System.Net.Http.Json;
using APIDemo.Api.Data;
using APIDemo.Tests.Fixture;
using APIDemo.Tests.Helper;
using FluentAssertions;

namespace APIDemo.Tests
{
    public class test1 : IClassFixture<DockerWebApplicationFactoryFixture>
    {
        private readonly DockerWebApplicationFactoryFixture _factory;
        private readonly HttpClient _client;

        public test1(DockerWebApplicationFactoryFixture factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task AddPersona()
        {
            // Arrange
            var newPersona = DataFixture.GetPersona(true);

            // Act
            var request = await _client.PostAsync(HttpHelper.Urls.AddPersona, HttpHelper.GetJsonHttpContent(newPersona));
            var response = await _client.GetAsync($"{HttpHelper.Urls.GetPersona}/{_factory.InitialPersona + 1}");
            var result = await response.Content.ReadFromJsonAsync<Persona>();

            // Assert
            request.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            result.Nombre.Should().Be(newPersona.Nombre);
            result.Apellido.Should().Be(newPersona.Apellido);
        }

        [Fact]
        public async Task GetPersonas()
        {
            // Act
            var response = await _client.GetAsync(HttpHelper.Urls.GetPersonas);
            var result = await response.Content.ReadFromJsonAsync<List<Persona>>();

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            result.Count.Should().Be(_factory.InitialPersona);
            result.Should().BeEquivalentTo(DataFixture.GetPersonas(_factory.InitialPersona), options => options.Excluding(t => t.Id));
        }              
    }
}
