﻿using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediTechCliente.Pages
{
    public class CrearDoctorModel : PageModel
    {
        public class Doctor
        {
            public int DoctorId { get; set; }

            [Required(ErrorMessage = "El campo Nombre es requerido.")]
            [StringLength(50, ErrorMessage = "El campo Nombre debe tener como máximo 50 caracteres.")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "El campo Apellido es requerido.")]
            [StringLength(50, ErrorMessage = "El campo Apellido debe tener como máximo 50 caracteres.")]
            public string Apellido { get; set; }

            [Required(ErrorMessage = "El campo Email es requerido.")]
            [EmailAddress(ErrorMessage = "El campo Email no tiene un formato válido.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "El campo Teléfono es requerido.")]
            [Phone(ErrorMessage = "El campo Teléfono no tiene un formato válido.")]
            public string Telefono { get; set; }

            [StringLength(100, ErrorMessage = "La dirección debe tener como máximo 100 caracteres.")]
            public string Direccion { get; set; }

            [Required(ErrorMessage = "El campo Especialidad es requerido.")]
            public string Especialidad { get; set; }

            public int AniosExperiencia { get; set; }
        }

        [BindProperty]
        public Doctor doc { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonDoctor = JsonSerializer.Serialize(doc); 

            using var httpClient = new HttpClient();
            var apiUrl = "https://localhost:7201/api/Doctor"; 
            var content = new StringContent(jsonDoctor, Encoding.UTF8, "application/json");

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
