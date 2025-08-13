using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IApartadoDA
    {
        Task<Guid> Agregar(ApartadoRequest apartado);
        Task<Guid> Editar(Guid Id, ApartadoRequest apartado);
        Task<Guid> Eliminar(Guid id);
        Task<IEnumerable<ApartadoResponse>> Obtener();
        Task<ApartadoResponse> Obtener(Guid id);
    }
}
