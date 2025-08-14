using Abstracciones.DA;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DA.Repositorios
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configutarion;
        private SqlConnection _connection;

        public RepositorioDapper(IConfiguration configutarion)
        {
            _configutarion = configutarion;
            _connection = new SqlConnection(_configutarion.GetConnectionString("BDSeguridad"));
        }

        public SqlConnection ObtenerRepositorioDapper()
        {
            return _connection;
        }
    }
}
