using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface IApartadoController
    {
        Task<IActionResult> Agregar(ApartadoRequest apartado);
        Task<IActionResult> Editar(Guid Id, ApartadoRequest apartado);
        Task<IActionResult> Eliminar(Guid id);
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid id);
    }
}
