using DataBaseFirst.Models;

namespace DataBaseFirst.Repository.Interfaces
{
    public interface ISalaCine
    {
        Task<List<SalaCine>> ListarSalasCineAsync();
        Task<SalaCine?> ObtenerSalaCineAsync(int idSalaCine);
        Task<int> RegistrarSalaCineAsync(SalaCine salaCine);
        Task<int> EditarSalaCineAsync(SalaCine pelicula);
        Task<int> EliminarSalaCineAsync(int id);
    }
}
