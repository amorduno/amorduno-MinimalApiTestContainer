namespace APIDemo.Api.Contracts
{
    public sealed class PersonaResponse
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;
    }
}
