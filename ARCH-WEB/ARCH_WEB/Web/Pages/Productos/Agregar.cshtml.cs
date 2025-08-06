using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Productos
{
    public class AgregarModel : PageModel
    {
        private IConfiguracion _configuracion;

        public AgregarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public Producto producto { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarProductos");
            var client = new HttpClient();

            var respuesta = await client.PostAsJsonAsync(endpoint, producto);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }


    }
}
