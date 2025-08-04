using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public IList<ClienteResponse> clientes { get; set; } = default!;
        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerClientes");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);
            var respuesta = await cliente.SendAsync(solicitud);

            respuesta.EnsureSuccessStatusCode();
             if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                clientes = JsonSerializer.Deserialize<List<ClienteResponse>>(resultado, opciones);
            }
        }
    }
}
