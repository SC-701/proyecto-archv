using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ClienteFlujo : IClienteFlujo
    {
        private IClienteDA _clienteDA;

        public ClienteFlujo(IClienteDA clienteDA)
        {
            _clienteDA = clienteDA;
        }

        public async Task<Guid> Agregar(Cliente cliente)
        {
            return await _clienteDA.Agregar(cliente);
        }

        public async Task<Guid> Editar(Guid Id, Cliente cliente)
        {
            return await _clienteDA.Editar(Id, cliente);
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            return await _clienteDA.Eliminar(id);
        }

        public async Task<IEnumerable<ClienteResponse>> Obtener()
        {
            return await _clienteDA.Obtener();
        }

        public async Task<ClienteResponse> Obtener(Guid id)
        {
            return await _clienteDA.Obtener(id);
        }
    }
}
