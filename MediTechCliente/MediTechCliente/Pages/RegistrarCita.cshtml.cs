using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediTechCliente.Pages
{
    public class CrearCitaModel : PageModel
    {
        public class RegistrarCita
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "El ID del Paciente es requerido.")]
            public int PacienteId { get; set; }

            [Required(ErrorMessage = "El ID del Servicio es requerido.")]
            public int ServicioId { get; set; }

            [Required(ErrorMessage = "El ID del Doctor es requerido.")]
            public int DoctorId { get; set; }

            [Required(ErrorMessage = "La nota es requerida.")]
            [MinLength(20, ErrorMessage = "La nota debe tener al menos 20 caracteres.")]
            public string Nota { get; set; }
        }

        [BindProperty]
        public RegistrarCita cita { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonCita = JsonSerializer.Serialize(cita);

            using var httpClient = new HttpClient();
            var apiUrl = "https://localhost:7201/api/RegistrarCita";
            var content = new StringContent(jsonCita, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
