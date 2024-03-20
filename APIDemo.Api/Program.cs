using Microsoft.EntityFrameworkCore;
using APIDemo.Api;
using APIDemo.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IPersonaService, PersonaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<PersonaDbContext>();
db?.Database.EnsureCreated();

app.ConfigureApi();

app.Run();

public partial class Program { }

