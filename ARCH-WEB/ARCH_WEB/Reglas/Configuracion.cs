using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private IConfiguration _configuracion;

        public Configuracion(IConfiguration configuration)
        {
            _configuracion = configuration;
        }
        public string ObtenerMetodo(string seccion, string nombre)
        {
            var UrlBase = ObtenerUrlBase(seccion);
            var Metodo = _configuracion.GetSection(seccion).Get<APIEndPoint>().Metodos.Where(m => m.Nombre == nombre).FirstOrDefault().Valor;
            return $"{UrlBase}/{Metodo}";
        }

        public string obtenerValor(string llave)
        {
            throw new NotImplementedException();
        }

        private string ObtenerUrlBase(string seccion)
        {
            return _configuracion.GetSection(seccion).Get<APIEndPoint>().UrlBase;
        }
    }
}
