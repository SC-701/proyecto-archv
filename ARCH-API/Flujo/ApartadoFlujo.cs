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
    public class ApartadoFlujo : IApartadoFlujo
    {
        private IApartadoDA _apartadoDA;

        public ApartadoFlujo(IApartadoDA apartadoDA)
        {
            _apartadoDA = apartadoDA;
        }

        public async Task<Guid> Agregar(ApartadoRequest apartado)
        {
            return await _apartadoDA.Agregar(apartado);
        }

        public async Task<Guid> Editar(Guid Id, ApartadoRequest apartado)
        {
            return await _apartadoDA.Editar(Id, apartado);
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            return await _apartadoDA.Eliminar(id);
        }

        public async Task<IEnumerable<ApartadoResponse>> Obtener()
        {
            return await _apartadoDA.Obtener();
        }

        public async Task<ApartadoResponse> Obtener(Guid id)
        {
            return await _apartadoDA.Obtener(id);
        }
    }
}
