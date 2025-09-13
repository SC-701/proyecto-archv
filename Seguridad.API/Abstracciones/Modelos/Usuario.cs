using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class UsuarioBase
    {

        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }
    }
    public class Usuario:UsuarioBase {
        [Required]
        public Guid Id { get; set; }
    }
}
