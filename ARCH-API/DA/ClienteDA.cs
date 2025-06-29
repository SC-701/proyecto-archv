using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class ClienteDA : IClienteDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        #region Constructor

        public ClienteDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(Cliente cliente)
        {
            string query = @"AgregarCliente";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Nombre = cliente.Nombre,
                Apellidos = cliente.Apellidos,
                Telefono = cliente.Telefono,
                Provincia = cliente.Provincia,
                DireccionExacta = cliente.DireccionExacta
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, Cliente cliente)
        {
            await VerificarClienteExiste(Id);
            string query = @"EditarCliente";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Nombre = cliente.Nombre,
                Apellidos = cliente.Apellidos,
                Telefono = cliente.Telefono,
                Provincia = cliente.Provincia,
                DireccionExacta = cliente.DireccionExacta
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            await VerificarClienteExiste(id);
            string query = @"EliminarCliente";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new { Id = id });

            return resultadoConsulta;
        }

        public async Task<IEnumerable<ClienteResponse>> Obtener()
        {
            string query = @"ObtenerClientes";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ClienteResponse>(query);
            return resultadoConsulta;
        }

        public async Task<ClienteResponse> Obtener(Guid id)
        {
            string query = @"ObtenerCliente";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ClienteResponse>(query, new { Id = id });
            return resultadoConsulta.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task VerificarClienteExiste(Guid Id)
        {
            ClienteResponse? resultadoConsultaCliente = await Obtener(Id);
            if (resultadoConsultaCliente == null)
            {
                throw new Exception("No se encontró el cliente");
            }
        }
        #endregion
    }
}
