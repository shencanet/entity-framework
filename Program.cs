
using proyectoeft;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
