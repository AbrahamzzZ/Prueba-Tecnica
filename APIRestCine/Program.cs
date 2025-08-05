/*using APIRestCine.Controllers;
using DataBaseFirst.Context;
using DataBaseFirst.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext con la cadena de conexión del appsettings.json
builder.Services.AddDbContext<PruebaTecnicaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"))
);

// Registrar el servicio para inyección de dependencias
builder.Services.AddScoped<PeliculaService>();



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

app.Run();*/

using APIRestCine.Controllers;
using DataBaseFirst.Context;
using DataBaseFirst.Repository;
using DataBaseFirst.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión
builder.Services.AddDbContext<PruebaTecnicaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"))
);

// Agregar servicios
builder.Services.AddControllers();
builder.Services.AddScoped<PeliculaRepository>();
builder.Services.AddScoped<PeliculaService>();
builder.Services.AddScoped<SalaCineRepository>();
builder.Services.AddScoped<SalaCineService>();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica");

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

