using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Web.Pages.Apartado
{
    public class CrearModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public CrearModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public ApartadoRequest apartado { get; set; } = new();

        public List<ClienteResponse> Clientes { get; set; } = new();
        public List<SelectListItem> ProductosSelectList { get; set; } = new();

        public async Task<IActionResult> OnGet()
        {
            await CargarClientesYProductos();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CargarClientesYProductos();
                return Page();
            }

            string url = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarApartado");

            using var cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
            var contenido = JsonContent.Create(apartado);
            var respuesta = await cliente.PostAsync(url, contenido);

                if (!respuesta.IsSuccessStatusCode)
            {
                var error = await respuesta.Content.ReadAsStringAsync();
                ViewData["ErrorStock"] = "No se pudo guardar el apartado. Verifique disponibilidad del producto.";
                await CargarClientesYProductos();
                return Page();
            }

            return RedirectToPage("Index");
        }

        private async Task CargarClientesYProductos()
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);

            var urlClientes = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerClientes");
            var respClientes = await http.GetAsync(urlClientes);
            if (respClientes.StatusCode == HttpStatusCode.OK)
            {
                var contenido = await respClientes.Content.ReadAsStringAsync();
                Clientes = JsonSerializer.Deserialize<List<ClienteResponse>>(contenido, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            }

            var urlProductos = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerProductos");
            var respProductos = await http.GetAsync(urlProductos);
            if (respProductos.StatusCode == HttpStatusCode.OK)
            {
                var contenido = await respProductos.Content.ReadAsStringAsync();
                var productos = JsonSerializer.Deserialize<List<ProductoResponse>>(contenido, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

                ProductosSelectList = productos.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Nombre} - ₡{p.Precio} - Talla: {p.Talla} ({(p.Cantidad > 0 ? $"{p.Cantidad} disponibles" : "Agotado")})",
                    Disabled = p.Cantidad == 0
                }).ToList();
            }
        }
    }
}
