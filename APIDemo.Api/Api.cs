using APIDemo.Api.Data;
using APIDemo.Api.Services;

namespace APIDemo.Api
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapPost("/AddPersona", AddPersona);           
            app.MapGet("/GetPersonas", GetPersonas);
            app.MapGet("/GetPersona/{id}", GetPersona);
            app.MapPut("/UpdatePersona/{id}", UpdatePersona);
        }
        private static async Task<IResult> AddPersona(Persona persona, IPersonaService personaService)
        {
            try
            {
                await personaService.AddAsync(persona);

                return Results.Created($"/persona/{persona.Id}", persona);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }        

        private static async Task<IResult> GetPersonas(IPersonaService personaService)
        {
            try
            {
                return Results.Ok(await personaService.GetAsync());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetPersona(int id, IPersonaService personaService)
        {
            try
            {
                var item = await personaService.GetAsync(id);
                if (item == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(item);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdatePersona(int id, Persona persona, IPersonaService personaService)
        {
            try
            {
                var item = await personaService.GetAsync(id);

                if (item is null) return Results.NotFound();

                persona.Id = id;
                var status = await personaService.UpdateAsync(persona);

                return status ? Results.NoContent() : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
