using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using DA;
using Flujo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartadosController : ControllerBase, IApartadoController
    {

        private IApartadoFlujo _apartadoFlujo;
        private ILogger<ApartadosController> _logger;

        public ApartadosController(IApartadoFlujo apartadoFlujo, ILogger<ApartadosController> logger)
        {
            _apartadoFlujo = apartadoFlujo;
            _logger = logger;
        }

        #region Operaciones

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] ApartadoRequest apartado)
        {
            var resultado = await _apartadoFlujo.Agregar(apartado);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute]Guid Id, [FromBody] ApartadoRequest apartado)
        {
            if (!await VerificarApartadoExiste(Id))
            {
                return NotFound("El apartado no existe");
            }
            var resultado = await _apartadoFlujo.Editar(Id, apartado);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar([FromRoute]Guid id)
        {
            if (!await VerificarApartadoExiste(id))
            {
                return NotFound("El apartado no existe");
            }
            var resultado = await _apartadoFlujo.Eliminar(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _apartadoFlujo.Obtener();
            if (!resultado.Any())
            {
                return NoContent();
            }
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener([FromRoute]Guid id)
        {
            var resultado = await _apartadoFlujo.Obtener(id);
            return Ok(resultado);
        }
        #endregion

        #region Helpers
        private async Task<bool> VerificarApartadoExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoApartadoExiste = await _apartadoFlujo.Obtener(Id);
            if (resultadoApartadoExiste != null)
            {
                resultadoValidacion = true;
            }
            return resultadoValidacion;
        }
        #endregion Helpers
    }
}
