using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Productos
{
    public class EditarModel : PageModel
    {
        private IConfiguracion _configuracion;

        [BindProperty]
        public ProductoResponse producto { get; set; } = default!;

        public Producto productoRequest { get; set; } = default!;


        public EditarModel(IConfiguracion configuracion)
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

            if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                producto = JsonSerializer.Deserialize<ProductoResponse>(resultado, opciones);
            }

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            Console.WriteLine("ID recibido: " + producto.Id);
            if (producto.Id == Guid.Empty)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EditarProductos");
            var client = new HttpClient();

            var respuesta = await client.PutAsJsonAsync<Producto>(string.Format(endpoint, producto.Id.ToString()), new Producto { Nombre = producto.Nombre, Precio = producto.Precio, Cantidad = producto.Cantidad, Talla = producto.Talla, Fecha = producto.Fecha });
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }
    }
}
