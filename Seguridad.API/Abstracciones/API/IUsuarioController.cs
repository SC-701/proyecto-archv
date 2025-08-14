using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.API
{
    public interface IUsuarioController
    {
        Task<IActionResult> PostAsync([FromBody]UsuarioBase usuario);
        Task<IActionResult> ObtenerUsuario([FromBody] UsuarioBase usuario);
    }
}
