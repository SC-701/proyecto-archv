using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IClienteController
    {
        Task<IActionResult> Agregar(Cliente cliente);
        Task<IActionResult> Editar(Guid Id, Cliente cliente);
        Task<IActionResult> Eliminar(Guid id);
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid id);
    }
}
