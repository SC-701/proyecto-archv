using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Flujo
{
    public interface IUsuarioFlujo
    {
        Task<Guid> CrearUsuario(UsuarioBase usuario);
        Task<Usuario> ObtenerUsuario(UsuarioBase usuario);
    }
}
