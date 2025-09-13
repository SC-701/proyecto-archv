using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class ProductoFlujo : IProductoFlujo
    {

        private IProductoDA _productoDA;


        public ProductoFlujo(IProductoDA productoDA)
        {
            _productoDA = productoDA;
        }

        public async Task<Guid> Agregar(Producto producto)
        {
            return await _productoDA.Agregar(producto);
        }

        public async Task<Guid> Editar(Guid Id, Producto producto)
        {
            return await _productoDA.Editar(Id, producto);
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            return await _productoDA.Eliminar(id);
        }

        public async  Task<IEnumerable<ProductoResponse>> Obtener()
        {
            return await _productoDA.Obtener();
        }

        public async  Task<ProductoResponse> Obtener(Guid id)
        {
            return await _productoDA.Obtener(id);
        }
    }
}
