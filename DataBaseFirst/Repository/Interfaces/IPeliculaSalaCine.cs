using DataBaseFirst.Models;

namespace DataBaseFirst.Repository.Interfaces
{
    public interface IPeliculaSalaCine
    {
        Task<List<PeliculaSalaCine>> ListarPeliculasSalasCineAsync();
        Task<int> RegistrarPeliculaSalaCineAsync(PeliculaSalaCine peliculaSalCine);
    }
}
