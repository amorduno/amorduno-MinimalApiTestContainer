using APIDemo.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Tests.Fixture
{
    internal class DataFixture
    {
        public static List<Persona> GetPersonas(int count, bool useNewSeed = false)
        {
            return GetPersonaFaker(useNewSeed).Generate(count);
        }
        public static Persona GetPersona(bool useNewSeed = false)
        {
            return GetPersonas(1, useNewSeed)[0];
        }

        private static Faker<Persona> GetPersonaFaker(bool useNewSeed)
        {
            var seed = 0;
            if (useNewSeed)
            {
                seed = Random.Shared.Next(10, int.MaxValue);
            }
            return new Faker<Persona>()
                .RuleFor(p => p.Nombre, f => f.Name.FirstName())
                .RuleFor(p => p.Apellido, f => f.Name.LastName())               
                .UseSeed(seed);
        }
    }
}
