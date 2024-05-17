using adsProyecto.DB;
using adsProyecto.Interfaces;
using adsProyecto.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

//Conf de dbcontext
builder.Services.AddDbContext<ApplicationDbContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
//linea que se agrego para la imyeccion de dependencias
builder.Services.AddScoped<IEstudiante, estudianteRepositorio>();
builder.Services.AddScoped<ICarrera, carreraRepositorio>();
builder.Services.AddScoped<IMaterias, MateriaRepositorio>();
builder.Services.AddScoped<IProfesor, profesorRepositorio>();
builder.Services.AddScoped<IGrupo, grupoRepositorio>();

// Configurando CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configuration =>
    {
        configuration.WithOrigins(builder.Configuration["allowedOrigins"]!).AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
