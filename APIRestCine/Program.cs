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
builder.Services.AddScoped<PeliculaSalaCineRepository>();
builder.Services.AddScoped<PeliculaSalaCineService>();

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

