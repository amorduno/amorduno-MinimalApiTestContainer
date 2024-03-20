using System;
using System.Text.Json;

namespace APIDemo.Api.Data
{
    public class Persona
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }               
    }
}
