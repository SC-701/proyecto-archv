using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Web.Pages.Apartado
{
    public class EditarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public EditarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public ApartadoRequest apartado { get; set; } = new();

        public List<ClienteResponse> Clientes { get; set; } = new();
        public List<ProductoResponse> Productos { get; set; } = new();

        public async Task<IActionResult> OnGet(Guid? id)
        {
            if (id == null) return NotFound();

            await CargarClientesYProductos();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerApartado").Replace("{0}", id.ToString());

            var cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(endpoint);

            if (respuesta.IsSuccessStatusCode)
            {
                var json = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var data = JsonSerializer.Deserialize<ApartadoResponse>(json, opciones);

                if (data != null)
                {
                    apartado = new ApartadoRequest
                    {
                        IdCliente = Clientes.FirstOrDefault(c => c.Nombre == data.Cliente)?.Id ?? Guid.Empty,
                        IdProducto = Productos.FirstOrDefault(p => p.Nombre == data.Producto)?.Id ?? Guid.Empty,
                        Abono = data.Abono,
                        Fecha = data.Fecha,
                        Estado = data.Estado,
                        Id = data.Id
                    };
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CargarClientesYProductos();
                return Page();
            }

            string url = _configuracion.ObtenerMetodo("ApiEndPoints", "EditarApartado").Replace("{0}", apartado.Id.ToString());

            var cliente = new HttpClient();
            var respuesta = await cliente.PutAsJsonAsync(url, apartado);

            if (!respuesta.IsSuccessStatusCode)
            {
                var error = await respuesta.Content.ReadAsStringAsync();
                throw new Exception($"Error al editar el apartado: {respuesta.StatusCode} - {error}");
            }

            return RedirectToPage("Index");
        }

        private async Task CargarClientesYProductos()
        {
            var http = new HttpClient();

            var endpointClientes = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerClientes");
            var respClientes = await http.GetAsync(endpointClientes);
            if (respClientes.StatusCode == HttpStatusCode.OK)
            {
                var contenido = await respClientes.Content.ReadAsStringAsync();
                Clientes = JsonSerializer.Deserialize<List<ClienteResponse>>(contenido, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }

            var endpointProductos = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerProductos");
            var respProductos = await http.GetAsync(endpointProductos);
            if (respProductos.StatusCode == HttpStatusCode.OK)
            {
                var contenido = await respProductos.Content.ReadAsStringAsync();
                Productos = JsonSerializer.Deserialize<List<ProductoResponse>>(contenido, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }
        }
    }
}