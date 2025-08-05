using DataBaseFirst.Models;
using DataBaseFirst.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRestCine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaCineController : ControllerBase
    {
        private readonly SalaCineService _salaCineService;

        public SalaCineController(SalaCineService salaCineService)
        {
            _salaCineService = salaCineService;
        }

        // GET: api/salaCine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaCine>>> GetSalasCine()
        {
            var peliculas = await _salaCineService.ListarSalasCineAsync();
            return Ok(peliculas);
        }

        // GET: api/salaCine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaCine>> GetSalaCine(int id)
        {
            var pelicula = await _salaCineService.ObtenerSalaCineAsync(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        // POST: api/salaCine
        [HttpPost]
        public async Task<ActionResult> CrearSalaCine([FromBody] SalaCine salaCine)
        {
            var resultado = await _salaCineService.RegistrarSalaCineAsync(salaCine);
            if (resultado > 0)
                return Ok(new { mensaje = "Sala cine registrada correctamente" });

            return BadRequest(new { mensaje = "No se pudo registrar la sala de cine" });
        }

        // PUT: api/salaCine/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPelicula(int id, [FromBody] SalaCine salaCine)
        {
            if (id != salaCine.IdSala)
                return BadRequest(new { mensaje = "El ID no coincide" });

            var resultado = await _salaCineService.EditarSalaCineAsync(salaCine);
            if (resultado > 0)
                return Ok(new { mensaje = "Sala cine actualizada correctamente" });

            return NotFound(new { mensaje = "Sala cine no encontrada" });
        }

        // DELETE: api/salaCine/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarSalaCine(int id)
        {
            var resultado = await _salaCineService.EliminarSalaCineAsync(id);
            if (resultado > 0)
                return Ok(new { mensaje = "Sala cine eliminada correctamente" });

            return NotFound(new { mensaje = "Sala cine no encontrada" });
        }
    }
}
