using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class ApartadoDA : IApartadoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public ApartadoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(ApartadoRequest apartado)
        {
            string query = @"AgregarApartado";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                IdCliente = apartado.IdCliente,
                IdProducto = apartado.IdProducto,
                Abono = apartado.Abodo,
                Restante = apartado.Restante,
                Fecha = apartado.Fecha,
                Estado = apartado.Estado
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, ApartadoRequest apartado)
        {
            await VerificarApartadoExiste(Id);
            string query = @"EditarApartado";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                IdCliente = apartado.IdCliente,
                IdProducto = apartado.IdProducto,
                Abono = apartado.Abodo,
                Restante = apartado.Restante,
                Fecha = apartado.Fecha,
                Estado = apartado.Estado
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            await VerificarApartadoExiste(id);
            string query = @"EliminarApartado";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new { Id = id });

            return resultadoConsulta;
        }

        public async Task<IEnumerable<ApartadoResponse>> Obtener()
        {
            string query = @"ObtenerApartados";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ApartadoResponse>(query);
            return resultadoConsulta;
        }

        public async Task<ApartadoResponse> Obtener(Guid id)
        {
            string query = @"ObtenerApartado";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ApartadoResponse>(query, new { Id = id });
            return resultadoConsulta.FirstOrDefault();
        }

        private async Task VerificarApartadoExiste(Guid Id)
        {
            ApartadoResponse? resultadoConsultaApartado = await Obtener(Id);
            if (resultadoConsultaApartado == null)
            {
                throw new Exception("No se encontró el apartado");
            }
        }
    }
}
