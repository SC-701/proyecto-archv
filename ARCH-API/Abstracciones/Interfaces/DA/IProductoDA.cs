using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IProductoDA
    {

        Task<Guid> Agregar(Producto producto);
        Task<Guid> Editar(Guid Id, Producto producto);
        Task<Guid> Eliminar(Guid id);
        Task<IEnumerable<ProductoResponse>> Obtener();
        Task<ProductoResponse> Obtener(Guid id);
    }
}
