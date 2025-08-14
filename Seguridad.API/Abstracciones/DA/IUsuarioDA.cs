using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.DA
{
    public interface IUsuarioDA
    {
        Task<Usuario> ObtenerUsuario(UsuarioBase usuario);

        Task<IEnumerable<Perfil>> ObtenerPerfilesxUsuario(UsuarioBase usuario);

        Task<Guid> CrearUsuario(UsuarioBase usuario);
    }
}
