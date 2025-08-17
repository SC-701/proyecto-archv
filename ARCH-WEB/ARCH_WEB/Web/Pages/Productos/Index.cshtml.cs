using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public IList<ProductoResponse> productos { get; set; } = default!;
        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerProductos");
            var cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var respuesta = await cliente.SendAsync(solicitud);

            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                productos = JsonSerializer.Deserialize<List<ProductoResponse>>(resultado, opciones);
            }
        }
    }
}
