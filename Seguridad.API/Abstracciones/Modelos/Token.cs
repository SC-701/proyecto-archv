using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Token
    {
        public bool ValidacionExitosa { get; set; }
        public string AccessToken { get; set; }
    }

    public class TokenConfiguracion
    {
        [Required]
        [StringLength(100,MinimumLength =32)]
        public string key { get; set; }
        [Required]
        public string Issuer { get; set; }
        [Required]
        public double Expires { get; set; }
        public string Audience { get; set; }
    }
}
