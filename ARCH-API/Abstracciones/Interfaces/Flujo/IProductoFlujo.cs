using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IProductoFlujo
    {

        Task<Guid> Agregar(Producto producto);
        Task<Guid> Editar(Guid Id, Producto producto);
        Task<Guid> Eliminar(Guid id);
        Task<IEnumerable<ProductoResponse>> Obtener();
        Task<ProductoResponse> Obtener(Guid id);
    }
}
