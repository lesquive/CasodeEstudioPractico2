using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediTechCliente.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<TipoReparacion> Servicios { get; private set; } = new List<TipoReparacion>();
        public string ErrorMessage { get; private set; }

        public async Task OnGetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<List<TipoReparacion>>("https://localhost:7201/api/Servicios");

            if (response != null)
            {
                Servicios = response;
            }
            else
            {
                ErrorMessage = "Error al obtener los servicios de MediTech";
            }
        }

        public class TipoReparacion
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }
    }
}