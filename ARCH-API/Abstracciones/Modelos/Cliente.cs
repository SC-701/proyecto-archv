using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class Cliente
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellidos es obligatorio.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo telefono es obligatorio.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo provincia es obligatorio.")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El campo direccion exacta es obligatorio.")]
        public string DireccionExacta { get; set; }
    }

    public class ClienteResponse : Cliente
    {
        public Guid Id { get; set; }
    }
}
