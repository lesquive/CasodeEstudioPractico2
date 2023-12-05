using System;
using System.ComponentModel.DataAnnotations;

namespace MediTechAPI.Models
{
	public class ServiciosModel
	{
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

	}
}

