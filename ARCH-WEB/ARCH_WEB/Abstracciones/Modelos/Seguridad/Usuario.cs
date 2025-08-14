using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Seguridad
{
    public class UsuarioBase
    {

        [Required]
        public string NombreUsuario { get; set; }
        public string? PasswordHash { get; set; }
        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

    }
    public class Usuario : UsuarioBase
    {
        [Required]
        public string Password { get; set; }
        public string ConfirmarPassword { get; set; }
    }
}
