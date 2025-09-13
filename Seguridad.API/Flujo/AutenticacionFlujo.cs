using Abstracciones.Reglas;
using Abstracciones.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class AutenticacionFlujo : IAutenticacionFlujo
    {

        private IAutenticacionBC _autenticacionBC;

        public AutenticacionFlujo(IAutenticacionBC autenticacionBC)
        {
            _autenticacionBC = autenticacionBC;
        }

        public async Task<Token> LoginAsync(LoginBase login)
        {
            return await _autenticacionBC.LoginAync(login);
        }
    }
}
