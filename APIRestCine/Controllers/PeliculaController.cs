using DataBaseFirst.Models;
using DataBaseFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRestCine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly PeliculaService _peliculaService;

        public PeliculaController(PeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        // GET: api/pelicula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            var peliculas = await _peliculaService.ListarPeliculasAsync();
            return Ok(peliculas);
        }

        // GET: api/pelicula/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPelicula(int id)
        {
            var pelicula = await _peliculaService.ObtenerPeliculaAsync(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        // GET: api/pelicula/MeteGol
        [HttpGet("/nombre{nombre}")]
        public async Task<ActionResult<Pelicula>> GetNombrePelicula(string nombre)
        {
            var pelicula = await _peliculaService.ObtenerNombrePeliculaAsync(nombre);

            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        // POST: api/pelicula
        [HttpPost]
        public async Task<ActionResult> CrearPelicula([FromBody] Pelicula pelicula)
        {
            var resultado = await _peliculaService.RegistrarPeliculaAsync(pelicula);
            if (resultado >0)
                return Ok(new { mensaje = "Película registrada correctamente" });

            return BadRequest(new { mensaje = "No se pudo registrar la película" });
        }

        // PUT: api/pelicula/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPelicula(int id, [FromBody] Pelicula pelicula)
        {
            if (id != pelicula.IdPelicula)
                return BadRequest(new { mensaje = "El ID no coincide" });

            var resultado = await _peliculaService.EditarPeliculaAsync(pelicula);
            if (resultado > 0)
                return Ok(new { mensaje = "Película actualizada correctamente" });

            return NotFound(new { mensaje = "Película no encontrada" });
        }

        // DELETE: api/pelicula/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarPelicula(int id)
        {
            var resultado = await _peliculaService.EliminarPeliculaAsync(id);
            if (resultado > 0)
                return Ok(new { mensaje = "Película eliminada correctamente" });

            return NotFound(new { mensaje = "Película no encontrada" });
        }
    }
}
