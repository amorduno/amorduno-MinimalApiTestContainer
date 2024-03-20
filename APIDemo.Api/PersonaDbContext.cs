using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using APIDemo.Api.Data;

namespace APIDemo.Api
{
    public class PersonaDbContext : DbContext
    {
        public DbSet<Persona> Persona => Set<Persona>();

        public PersonaDbContext(DbContextOptions<PersonaDbContext> options)
            : base(options)
        {
        }
    }
}
