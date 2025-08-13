using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Flujo
{
    public interface IAutenticacionFlujo
    {
        Task<Token> LoginAsync(LoginBase login);
    }
}
