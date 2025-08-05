using DataBaseFirst.Context;
using DataBaseFirst.Models;
using DataBaseFirst.Models.Dto;
using DataBaseFirst.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst.Repository
{
    public class PeliculaSalaCineRepository : IPeliculaSalaCine
    {
        private readonly PruebaTecnicaDbContext _context;

        public PeliculaSalaCineRepository(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        public async Task<List<PeliculaSalaCine>> ListarPeliculasSalasCineAsync()
        {
            return await _context.PeliculaSalaCines
                .FromSqlRaw("EXEC PA_LISTA_PELICULA_SALA_CINE")
                .ToListAsync();
        }

        public async Task<List<FechaPublicacionDto?>> BuscarPeliculaFechaPublicacionAsync(string fechaPublicacion)
        {
            var param = new SqlParameter("@Fecha_Publicacion", fechaPublicacion);

            var resultado = await _context.FechaPublicacion
                .FromSqlRaw("EXEC PA_BUSCAR_PELICULA_FECHA_PUBLICACION @Fecha_Publicacion", param)
                .AsNoTracking()
                .ToListAsync();

            return resultado;
        }

        public async Task<int> RegistrarPeliculaSalaCineAsync(PeliculaSalaCine peliculaSalaCine)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC PA_ASIGNAR_PELICULAS_SALA_CINE @Id_Pelicula, @Id_Sala, @Fecha_Publicacion, @Fecha_Fin",
                new SqlParameter("@Id_Pelicula", peliculaSalaCine.IdPelicula ?? (object)DBNull.Value),
                new SqlParameter("@Id_Sala", peliculaSalaCine.IdSalaCine ?? (object)DBNull.Value),
                new SqlParameter("@Fecha_Publicacion", peliculaSalaCine.FechaPublicacion ?? (object)DBNull.Value),
                new SqlParameter("@Fecha_Fin", peliculaSalaCine.FechaFin ?? (object)DBNull.Value)
            );
        }
    }
}
