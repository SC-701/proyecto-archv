using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase, IProductoController
    {
        private IProductoFlujo _productoFlujo;
        private ILogger<ProductosController> _logger;

        public ProductosController(IProductoFlujo productoFlujo, ILogger<ProductosController> logger)
        {
            _productoFlujo = productoFlujo;
            _logger = logger;
        }

        #region Operaciones
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Producto producto)
        {
            var resultado = await _productoFlujo.Agregar(producto);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] Producto producto)
        {
            if (!await VerificarProductoExiste(Id))
            {
                return NotFound("El producto no existe");
            }
            var resultado = await _productoFlujo.Editar(Id, producto);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid id)
        {
            if (!await VerificarProductoExiste(id))
            {
                return NotFound("El producto no existe");
            }
            var resultado = await _productoFlujo.Eliminar(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _productoFlujo.Obtener();
            if (!resultado.Any())
            {
                return NoContent();
            }
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid id)
        {
            var resultado = await _productoFlujo.Obtener(id);
            return Ok(resultado);
        }
        #endregion

        #region Helpers
        private async Task<bool> VerificarProductoExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoProductoExiste = await _productoFlujo.Obtener(Id);
            if (resultadoProductoExiste != null)
            {
                resultadoValidacion = true;
            }
            return resultadoValidacion;
        }
        #endregion
    }
}
