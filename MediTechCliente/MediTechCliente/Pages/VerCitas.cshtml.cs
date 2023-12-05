using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static MediTechCliente.Pages.IndexModel;

namespace MediTechCliente.Pages
{
    public class VerCitasModel : PageModel
    {
        public class RegistrarCitaModel
        {
            public int Id { get; set; }
            public int PacienteId { get; set; }
            public int ServicioId { get; set; }
            public int DoctorId { get; set; }
            public string Nota { get; set; }
        }

        private readonly IHttpClientFactory _httpClientFactory;

        public VerCitasModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<RegistrarCitaModel> citas { get; private set; } = new List<RegistrarCitaModel>();
        public string ErrorMessage { get; private set; }

        public async Task OnGetAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetFromJsonAsync<List<RegistrarCitaModel>>("https://localhost:7201/api/RegistrarCita");

            if (response != null)
            {
                citas = response;
            }
            else
            {
                ErrorMessage = "Error al obtener los servicios de MediTech";
            }
        }
    }
}
