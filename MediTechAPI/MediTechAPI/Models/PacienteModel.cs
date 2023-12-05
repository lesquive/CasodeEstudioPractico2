using System;
using System.ComponentModel.DataAnnotations;

namespace MediTechAPI.Models
{
	public class PacienteModel
	{
        [Key]
        public int ClienteId { get; set; }

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
    }
}

