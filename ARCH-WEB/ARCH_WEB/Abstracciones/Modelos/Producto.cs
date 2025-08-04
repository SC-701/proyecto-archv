using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Producto
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Precio es obligatorio.")]
        public string Precio { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio.")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "El campo Talla es obligatorio.")]
        public string Talla { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
        public string Fecha { get; set; }
    }

    public class ProductoResponse : Producto
    {
        public Guid Id { get; set; }
    }
}
