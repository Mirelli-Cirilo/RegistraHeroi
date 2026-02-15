using Microsoft.EntityFrameworkCore;
using RegisterHeroApi.Data;
using RegisterHeroApi.Models;
using RegisterHeroApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Context
builder.Services.AddDbContext<RegisterHeroContext>(options =>
    options.UseInMemoryDatabase("RegisterHeroDb"));

builder.Services.AddScoped<IRegisterHeroService, HeroiService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RegisterHeroContext>();

    if (!context.Superpoderes.Any())
    {
        context.Superpoderes.AddRange(
            new Superpoder { SuperPoder = "Super Força", Descricao = "Força sobre-humana" },
            new Superpoder { SuperPoder = "Voo", Descricao = "Capacidade de voar" },
            new Superpoder { SuperPoder = "Invisibilidade", Descricao = "Fica invisível" },
            new Superpoder { SuperPoder = "Super Velocidade", Descricao = "Velocidade extrema" },
            new Superpoder { SuperPoder = "Telepatia", Descricao = "Comunicação Mental"}
        );

        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
