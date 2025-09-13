using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Clientes
{
    public class AgregarModel : PageModel
    {
        private IConfiguracion _configuracion;

        public AgregarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public Cliente cliente { get; set; } = default!;
        public List<string> provincias { get; set; } = new();
        public IActionResult OnGet()
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

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
           if (!ModelState.IsValid)
               return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarCliente");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);

            var respuesta = await client.PostAsJsonAsync(endpoint, cliente);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }


    }
}
