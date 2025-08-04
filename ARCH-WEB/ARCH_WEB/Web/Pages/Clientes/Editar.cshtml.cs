using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Clientes
{
    public class EditarModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public ClienteResponse cliente { get; set; } = default!;

        public Cliente clienteRequest { get; set; } = default!;

        public List<string> provincias { get; set; } = new();

        public EditarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task<ActionResult> OnGet(Guid? id)
        {
            provincias = new List<string>
            {
                "San José",
                "Alajuela",
                "Cartago",
                "Heredia",
                "Guanacaste",
                "Puntarenas",
                "Limón"
            };

            if (id == null)
                return NotFound();
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerCliente");
            var client = new HttpClient();

            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await client.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                cliente = JsonSerializer.Deserialize<ClienteResponse>(resultado, opciones);
            }

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            Console.WriteLine("ID recibido: " + cliente.Id);
            if (cliente.Id == Guid.Empty)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EditarCliente");
            var client = new HttpClient();

            var respuesta = await client.PutAsJsonAsync<Cliente>(string.Format(endpoint, cliente.Id.ToString()), new Cliente { Nombre = cliente.Nombre, Apellidos = cliente.Apellidos, Telefono = cliente.Telefono, Provincia = cliente.Provincia, DireccionExacta = cliente.DireccionExacta });
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }
    }
}
