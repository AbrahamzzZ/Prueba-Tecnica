using DataBaseFirst.Context;
using DataBaseFirst.Models;
using DataBaseFirst.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.Repository
{
    public class SalaCineRepository: ISalaCine
    {
        private readonly PruebaTecnicaDbContext _context;

        public SalaCineRepository(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalaCine>> ListarSalasCineAsync()
        {
            return await _context.SalaCines
                .FromSqlRaw("EXEC PA_LISTA_SALA_CINE")
                .ToListAsync();
        }

        public async Task<SalaCine?> ObtenerSalaCineAsync(int idSalaCine)
        {
            var idParam = new SqlParameter("@Id_Sala", idSalaCine);
            return await Task.Run(() => _context.SalaCines
                .FromSqlRaw("EXEC PA_OBTENER_SALA_CINE @Id_Sala", idParam)
                .AsNoTracking()
                .AsEnumerable()
                .FirstOrDefault());
        }

        public async Task<int> RegistrarSalaCineAsync(SalaCine salaCine)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC PA_REGISTRAR_SALA @Nombre, @Estado",
                new SqlParameter("@Nombre", salaCine.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Estado", salaCine.Estado ?? false)
            );
        }

        public async Task<int> EditarSalaCineAsync(SalaCine salaCine)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC PA_EDITAR_SALA @Id_Sala, @Nombre, @Estado",
                new SqlParameter("@Id_Sala", salaCine.IdSala),
                new SqlParameter("@Nombre", salaCine.Nombre ?? (object)DBNull.Value),
                new SqlParameter("@Estado", salaCine.Estado ?? false)
            );
        }

        public async Task<int> EliminarSalaCineAsync(int id)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC PA_ELIMINAR_SALA @Id_Sala",
                new SqlParameter("@Id_Sala", id)
            );
        }
    }
}
