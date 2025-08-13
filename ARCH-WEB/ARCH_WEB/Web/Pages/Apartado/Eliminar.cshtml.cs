using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Apartado
{
    public class EliminarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public EliminarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public ApartadoResponse Apartado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerApartado").Replace("{0}", id.ToString());

            var cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(endpoint);

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (Apartado.Id == Guid.Empty)
                return NotFound();

            string url = _configuracion.ObtenerMetodo("ApiEndPoints", "EliminarApartado").Replace("{0}", Apartado.Id.ToString());

            var cliente = new HttpClient();
            var respuesta = await cliente.DeleteAsync(url);

            if (!respuesta.IsSuccessStatusCode)
            {
                var error = await respuesta.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar apartado: {respuesta.StatusCode} - {error}");
            }

            return RedirectToPage("Index");
        }
    }
}