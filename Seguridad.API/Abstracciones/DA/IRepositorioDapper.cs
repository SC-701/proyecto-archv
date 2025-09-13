using System.Data.SqlClient;

namespace Abstracciones.DA
{
    public interface IRepositorioDapper
    {
        SqlConnection ObtenerRepositorioDapper();
    }
}
