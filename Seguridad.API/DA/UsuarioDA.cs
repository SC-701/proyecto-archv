using Abstracciones.DA;
using Abstracciones.Modelos;
using System.Data.SqlClient;
using Dapper;
using Helpers;

namespace DA
{
    public class UsuarioDA : IUsuarioDA
    {
        IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public UsuarioDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> CrearUsuario(UsuarioBase usuario)
        {
            var sql = "[AgregarUsuario]";
            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new { NombreUsuario=usuario.NombreUsuario, PasswordHash=usuario.PasswordHash, CorreoElectronico=usuario.CorreoElectronico });
            return resultado;
        }

        public async Task<IEnumerable<Perfil>> ObtenerPerfilesxUsuario(UsuarioBase usuario)
        {
            string sql = @"[ObtenerPerfilesxUsuario]";
            var resultado = await _sqlConnection.QueryAsync<Perfil>(sql, new { CorreoElectronico = usuario.CorreoElectronico, NombreUsuario = usuario.NombreUsuario });
            return resultado;
        }

        public async Task<Usuario> ObtenerUsuario(UsuarioBase usuario)
        {
            string sql = @"[ObtenerUsuario]";
            var resultado = await _sqlConnection.QueryAsync<Usuario>(sql, new { CorreoElectronico = usuario.CorreoElectronico, NombreUsuario = usuario.NombreUsuario });
            return resultado.FirstOrDefault();
        }
    }
}
