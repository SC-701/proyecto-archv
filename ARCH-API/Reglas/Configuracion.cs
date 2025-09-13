using Abstracciones.Interfaces.Reglas;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private IConfiguration _configuration;

        public Configuracion(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ObtenerMetodo(string seccion, string nombre)
        {
            throw new NotImplementedException();
        }

        public string obtenerValor(string llave)
        {
            throw new NotImplementedException();
        }
    }
}
