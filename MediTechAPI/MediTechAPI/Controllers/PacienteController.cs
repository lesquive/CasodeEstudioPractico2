using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediTechAPI.Models;
using MediTechAPI.Services;

namespace MediTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService ?? throw new ArgumentNullException(nameof(pacienteService));
        }

        [HttpGet]
        public ActionResult<List<PacienteModel>> GetAllPacientes()
        {
            var pacientes = _pacienteService.GetAllPacientes();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public ActionResult<PacienteModel> GetPacienteById(int id)
        {
            var paciente = _pacienteService.GetPacienteById(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPost]
        public IActionResult CreatePaciente(PacienteModel nuevoPaciente)
        {
            _pacienteService.CreatePaciente(nuevoPaciente);
            return CreatedAtAction(nameof(GetPacienteById), new { id = nuevoPaciente.ClienteId }, nuevoPaciente);
        }

    }
}
