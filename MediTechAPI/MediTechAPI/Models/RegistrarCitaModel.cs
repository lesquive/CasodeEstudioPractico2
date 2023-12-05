using System;
using System.ComponentModel.DataAnnotations;

namespace MediTechAPI.Models
{
    public class RegistrarCitaModel
    {
        [Key]
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int ServicioId { get; set; }
        public int DoctorId { get; set; }

        [MinLength(20, ErrorMessage = "La nota debe tener al menos 20 caracteres.")]
        public string Nota { get; set; }
    }
}
