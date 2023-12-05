using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediTechAPI.Models;
using MediTechAPI.Services;

namespace MediTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }

        [HttpGet]
        public ActionResult<List<DoctorModel>> GetAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public ActionResult<DoctorModel> GetDoctorById(int id)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult CreateDoctor(DoctorModel nuevoDoctor)
        {
            _doctorService.CreateDoctor(nuevoDoctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = nuevoDoctor.DoctorId }, nuevoDoctor);
        }

    }
}
