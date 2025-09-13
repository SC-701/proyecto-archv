using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Apartado
    {
        [Required(ErrorMessage = "El campo abono es obligatorio.")]
        public decimal Abono { get; set; }

        public Decimal Restante { get; set; }

        [Required(ErrorMessage = "El campo fecha es obligatorio.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public string Estado { get; set; } = string.Empty;
    }

    public class ApartadoRequest : Apartado
    {
        public Guid IdCliente { get; set; }
        public Guid IdProducto { get; set; }
    }

    public class ApartadoResponse : Apartado
    {
        public Guid Id { get; set; }

        public Guid IdCliente { get; set; }
        public Guid IdProducto { get; set; }

        public string Cliente { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;

        public decimal PrecioProducto { get; set; }
        public decimal Restante => PrecioProducto - Abono;
    }
}
