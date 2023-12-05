using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediTechAPI.Models;
using MediTechAPI.Services;

namespace MediTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarCitaController : ControllerBase
    {
        private readonly RegistrarCitaService _citaService;

        public RegistrarCitaController(RegistrarCitaService citaService)
        {
            _citaService = citaService ?? throw new ArgumentNullException(nameof(citaService));
        }

        [HttpGet]
        public ActionResult<List<RegistrarCitaModel>> GetAllCitas()
        {
            var citas = _citaService.GetAllCitas();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public ActionResult<RegistrarCitaModel> GetCitaById(int id)
        {
            var cita = _citaService.GetCitaById(id);
            if (cita == null)
            {
                return NotFound();
            }
            return Ok(cita);
        }

        [HttpPost]
        public IActionResult CreateCita(RegistrarCitaModel nuevaCita)
        {
            _citaService.CreateCita(nuevaCita);
            return CreatedAtAction(nameof(GetCitaById), new { id = nuevaCita.Id }, nuevaCita);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCita(int id, RegistrarCitaModel citaActualizada)
        {

            Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:7077");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

            var existingCita = _citaService.GetCitaById(id);
            if (existingCita == null)
            {
                return NotFound();
            }

            _citaService.UpdateCita(citaActualizada);
            return NoContent();
        }

    }
}
