using APIRestCine.Controllers;
using DataBaseFirst.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext con la cadena de conexión del appsettings.json
builder.Services.AddDbContext<PruebaTecnicaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"))
);

// Registrar el servicio para inyección de dependencias
builder.Services.AddScoped<PeliculaController>();
builder.Services.AddScoped<SalaCineController>();
builder.Services.AddScoped<PeliculaSalaCineController>();


// Agregar servicios para controladores
builder.Services.AddControllers();

// Creacion de una nueva politica
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
