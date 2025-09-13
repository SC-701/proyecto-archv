using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface IProductoController
    {
        Task<IActionResult> Agregar(Producto producto);
        Task<IActionResult> Editar(Guid Id, Producto producto);
        Task<IActionResult> Eliminar(Guid id);
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid id);



    }
}
