using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IClienteFlujo
    {
        Task<Guid> Agregar(Cliente cliente);
        Task<Guid> Editar(Guid Id, Cliente cliente);
        Task<Guid> Eliminar(Guid id);
        Task<IEnumerable<ClienteResponse>> Obtener();
        Task<ClienteResponse> Obtener(Guid id);
    }
}
