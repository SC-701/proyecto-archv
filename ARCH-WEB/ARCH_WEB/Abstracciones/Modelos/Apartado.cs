using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class Apartado
    {
        [Required(ErrorMessage = "El campo Cliente es obligatorio.")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "El campo Producto es obligatorio.")]
        public Guid IdProducto { get; set; }

        [Required(ErrorMessage = "El campo Abodo es obligatorio.")]
        public decimal Abono { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio.")]
        public string Estado { get; set; } = string.Empty;
    }

    public class ApartadoRequest : Apartado
    {
        public Guid Id { get; set; }
    }

    public class ApartadoResponse : Apartado
    {
        public Guid Id { get; set; }

        public string Cliente { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;

        public decimal PrecioProducto { get; set; }

        public decimal Restante => PrecioProducto - Abono;
    }

}
