using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class ProductoDA : IProductoDA
    {

        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public ProductoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }


        public async Task<Guid> Agregar(Producto producto)
        {
            string query = @"AgregarProducto";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Cantidad = producto.Cantidad,
                Talla = producto.Talla,
                Fecha = producto.Fecha
            });

            return resultadoConsulta;
        }


        public async Task<Guid> Editar(Guid Id, Producto producto)
        {
            await VerificarProductoExiste(Id);
            string query = @"EditarCliente";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Cantidad = producto.Cantidad,
                Talla = producto.Talla,
                Fecha = producto.Fecha
            });

            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            await VerificarProductoExiste(id);
            string query = @"ProductoCliente";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new { Id = id });

            return resultadoConsulta;
        }

        public async Task<IEnumerable<ProductoResponse>> Obtener()
        {
            string query = @"ObtenerProductos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ProductoResponse>(query);
            return resultadoConsulta;
        }

        public async  Task<ProductoResponse> Obtener(Guid id)
        {
            string query = @"ObtenerProducto";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ProductoResponse>(query, new { Id = id });
            return resultadoConsulta.FirstOrDefault();
        }

        private async Task VerificarProductoExiste(Guid Id)
        {
            ProductoResponse? resultadoConsultaProducto = await Obtener(Id);
            if (resultadoConsultaProducto == null)
            {
                throw new Exception("No se encontró el Producto");
            }
        }



    }
}
