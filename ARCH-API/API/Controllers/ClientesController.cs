using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase, IClienteController
    {
        private IClienteFlujo _clienteFlujo;
        private ILogger<ClientesController> _logger;

        public ClientesController(IClienteFlujo clienteFlujo, ILogger<ClientesController> logger)
        {
            _clienteFlujo = clienteFlujo;
            _logger = logger;
        }

        #region Operaciones
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Cliente cliente)
        {
            var resultado = await _clienteFlujo.Agregar(cliente);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] Cliente cliente)
        {
            if(!await VerificarClienteExiste(Id))
            {
                return NotFound("El cliente no existe");
            }
            var resultado = await _clienteFlujo.Editar(Id, cliente);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid id)
        {
            if (!await VerificarClienteExiste(id))
            {
                return NotFound("El cliente no existe");
            }
            var resultado = await _clienteFlujo.Eliminar(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _clienteFlujo.Obtener();
            if (!resultado.Any())
            {
                return NoContent();
            }
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid id)
        {
            var resultado = await _clienteFlujo.Obtener(id);
            return Ok(resultado);
        }
        #endregion

        #region Helpers
        private async Task<bool> VerificarClienteExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoClienteExiste = await _clienteFlujo.Obtener(Id);
            if (resultadoClienteExiste != null)
            {
                resultadoValidacion = true;
            }
            return resultadoValidacion;
        }
        #endregion Helpers
    }
}
