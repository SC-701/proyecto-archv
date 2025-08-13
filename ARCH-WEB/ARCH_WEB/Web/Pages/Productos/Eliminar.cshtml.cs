using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Productos
{
    public class EliminarModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public ProductoResponse producto { get; set; } = default!;
        public EliminarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<ActionResult> OnGet(Guid? id)
        {
            if (id == null)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerProducto");
            var client = new HttpClient();

            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await client.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                producto = JsonSerializer.Deserialize<ProductoResponse>(resultado, opciones);
            }
            return Page();
        }

        public async Task<ActionResult> OnPost(Guid? id)
        {
            if (id == Guid.Empty)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EliminarProductos");
            var client = new HttpClient();

            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, id));
            var respuesta = await client.SendAsync(solicitud);

            if (!respuesta.IsSuccessStatusCode)
            {
                if (respuesta.StatusCode == HttpStatusCode.InternalServerError)
                {
                    ViewData["Error"] = "No se puede eliminar este producto porque está siendo apartado por uno o más clientes.";
                    return Page();
                }

                ViewData["Error"] = $"Error inesperado: {respuesta.StatusCode}";
                return Page();
            }

            return RedirectToPage("./Index");
        }

    }
}