using Abstracciones.API;
using Abstracciones.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller, IUsuarioController
    {
        private IUsuarioFlujo _usuarioFlujo;

        public UsuarioController(IUsuarioFlujo usuarioFlujo)
        {
            _usuarioFlujo = usuarioFlujo;
        }

        [Authorize(Roles ="1")]
        [HttpPost("ObtenerInformacionUsuario")]
        public async Task<IActionResult> ObtenerUsuario([FromBody] UsuarioBase usuario)
        {
            return Ok( await _usuarioFlujo.ObtenerUsuario(usuario));
        }

        [AllowAnonymous]
        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> PostAsync([FromBody] UsuarioBase usuario)
        {
            var resultado=await _usuarioFlujo.CrearUsuario(usuario);
            return CreatedAtAction(nameof(ObtenerUsuario),null, resultado);
        }




    }
}
