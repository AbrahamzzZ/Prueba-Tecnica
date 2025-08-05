using DataBaseFirst.Models;
using DataBaseFirst.Repository;

namespace DataBaseFirst.Services
{
    public class PeliculaService
    {
        private readonly PeliculaRepository _peliculaRepository;

        public PeliculaService(PeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        public async Task<List<Pelicula>> ListarPeliculasAsync()
        {
            return await _peliculaRepository.ListarPeliculasAsync();
        }

        public async Task<Pelicula?> ObtenerPeliculaAsync(int idPelicula)
        {
            return await _peliculaRepository.ObtenerPeliculaAsync(idPelicula);
        }

        public async Task<Pelicula?> ObtenerNombrePeliculaAsync(string nombrePelicula)
        {
            return await _peliculaRepository.ObtenerNombrePeliculaAsync(nombrePelicula);
        }

        public async Task<int> RegistrarPeliculaAsync(Pelicula pelicula)
        {
            return await _peliculaRepository.RegistrarPeliculaAsync(pelicula);
        }

        public async Task<int> EditarPeliculaAsync(Pelicula pelicula)
        {
            return await _peliculaRepository.EditarPeliculaAsync(pelicula);
        }

        public async Task<int> EliminarPeliculaAsync(int id)
        {
            return await _peliculaRepository.EliminarPeliculaAsync(id);
        }
    }
}
