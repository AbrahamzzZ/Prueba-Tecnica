using DataBaseFirst.Models;
using DataBaseFirst.Models.Dto;
using DataBaseFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRestCine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaSalaCineController : ControllerBase
    {
        private readonly PeliculaSalaCineService _peliculaSalaCineService;

        public PeliculaSalaCineController(PeliculaSalaCineService peliculaSalaCineService)
        {
            _peliculaSalaCineService = peliculaSalaCineService;
        }

        // GET: api/salaCine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeliculaSalaCine>>> GetPeliculasSalasCine()
        {
            var peliculas = await _peliculaSalaCineService.ListarPeliculasSalasCineAsync();
            return Ok(peliculas);
        }

        // GET: api/salaCine/2025-08-5
        [HttpGet("fecha-publicacion/{fechaPublicacion}")]
        public async Task<ActionResult<IEnumerable<FechaPublicacionDto>>> GetFechaPulblicacionPelicula(string fechaPublicacion)
        {
            var resultado = await _peliculaSalaCineService.BuscarPeliculaFechaPublicacionAsync(fechaPublicacion);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        // POST: api/salaCine
        [HttpPost]
        public async Task<ActionResult> CrearSalaCine([FromBody] PeliculaSalaCine salaCine)
        {
            var resultado = await _peliculaSalaCineService.RegistrarPeliculaSalaCineAsync(salaCine);
            if (resultado > 0)
                return Ok(new { mensaje = "Pelicula registrada correctamente en la sala" });

            return BadRequest(new { mensaje = "No se pudo registrar la pelicula en sala de cine" });
        }
    }
}
