using DataBaseFirst.Context;
using DataBaseFirst.Models;
using DataBaseFirst.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.Repository
{
    public class PeliculaRepository: IPelicula
    {
        private readonly PruebaTecnicaDbContext _context;

        public PeliculaRepository(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pelicula>> ListarPeliculasAsync()
        {
            return await _context.Peliculas
                .FromSqlRaw("EXEC PA_LISTA_PELICULA")
                .ToListAsync();
        }

        public async Task<Pelicula?> ObtenerPeliculaAsync(int idPelicula)
        {
            var idParam = new SqlParameter("@Id_Pelicula", idPelicula);
            return await Task.Run(() => _context.Peliculas
                .FromSqlRaw("EXEC PA_OBTENER_PELICULA @Id_Pelicula", idParam)
                .AsNoTracking()
                .AsEnumerable()
                .FirstOrDefault());
        }

        public async Task<Pelicula?> ObtenerNombrePeliculaAsync(string nombrePelicula)
        {
            var idParam = new SqlParameter("@Nombre", nombrePelicula);
            return await Task.Run(() => _context.Peliculas
                .FromSqlRaw("EXEC PA_BUSCAR_PELICULA @Nombre", idParam)
                .AsNoTracking()
                .AsEnumerable()
                .FirstOrDefault());
        }

        public async Task<int> RegistrarPeliculaAsync(Pelicula pelicula)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC PA_REGISTRAR_PELICULA @Nombre, @Duracion, @Estado",
                new SqlParameter("@Nombre", pelicula.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Duracion", pelicula.Duracion ?? (object)DBNull.Value),
                new SqlParameter("@Estado", pelicula.Estado ?? false)
            );
        }

        public async Task<int> EditarPeliculaAsync(Pelicula pelicula)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC PA_EDITAR_PELICULA @Id_Pelicula, @Nombre, @Duracion, @Estado",
                new SqlParameter("@Id_Pelicula", pelicula.IdPelicula),
                new SqlParameter("@Nombre", pelicula.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Duracion", pelicula.Duracion ?? (object)DBNull.Value),
                new SqlParameter("@Estado", pelicula.Estado ?? false)
            );
        }

        public async Task<int> EliminarPeliculaAsync(int id)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC PA_ELIMINAR_PELICULA @Id_Pelicula",
                new SqlParameter("@Id_Pelicula", id)
            );
        }
    }
}
