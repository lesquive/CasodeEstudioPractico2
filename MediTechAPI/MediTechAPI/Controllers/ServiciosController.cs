using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediTechAPI.Models;
using MediTechAPI.Services;

namespace MediTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly ServiciosService _serviciosService;

        public ServiciosController(ServiciosService serviciosService)
        {
            _serviciosService = serviciosService ?? throw new ArgumentNullException(nameof(serviciosService));
        }

        [HttpGet]
        public ActionResult<List<ServiciosModel>> GetAllServicios()
        {
            var servicios = _serviciosService.GetAllServicios();
            return Ok(servicios);
        }

        [HttpGet("{id}")]
        public ActionResult<ServiciosModel> GetServicioById(int id)
        {
            var servicio = _serviciosService.GetServicioById(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return Ok(servicio);
        }

        [HttpPost]
        public IActionResult CreateServicio(ServiciosModel nuevoServicio)
        {
            _serviciosService.CreateServicio(nuevoServicio);
            return CreatedAtAction(nameof(GetServicioById), new { id = nuevoServicio.Id }, nuevoServicio);
        }

    }
}
