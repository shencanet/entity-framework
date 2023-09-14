using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
 //builder.Services.AddSqlServer<TareasContext>("Data Source=SHEN-PC\\SQLEXPRESS;Initial Catalog=TareasDB;user id SHEN-PC\\santi;password=almera;");
 builder.Services.AddDbContext<TareasContext>(options => options.UseSqlServer("Data Source=(local); Initial Catalog= master;Trusted_Connection=True; Integrated Security=True"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());

});

app.Run();
