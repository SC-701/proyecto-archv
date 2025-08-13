using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Apartado
{
    public class DetallesModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public DetallesModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public ApartadoResponse Apartado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            string url = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerApartado").Replace("{0}", id.ToString());

            var cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(url);

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Apartado = JsonSerializer.Deserialize<ApartadoResponse>(contenido, opciones)!;
            }
            else
            {
                return NotFound("Apartado no encontrado");
            }

            return Page();
        }
    }
}