using DataBaseFirst.Models;

namespace DataBaseFirst.Repository.Interfaces
{
    public interface IPelicula
    {
        Task<List<Pelicula>> ListarPeliculasAsync();
        Task<Pelicula?> ObtenerPeliculaAsync(int idPelicula);
        Task<Pelicula?> ObtenerNombrePeliculaAsync(string nombrePelicula);
        Task<int> RegistrarPeliculaAsync(Pelicula pelicula);
        Task<int> EditarPeliculaAsync(Pelicula pelicula);
        Task<int> EliminarPeliculaAsync(int id);
    }
}
