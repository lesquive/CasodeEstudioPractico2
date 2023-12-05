using System;
using System.Collections.Generic;
using System.Linq;
using MediTechAPI.Models;

namespace MediTechAPI.Services
{
    public class PacienteService
    {
        private readonly MediTechDbContext _context;

        public PacienteService(MediTechDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<PacienteModel> GetAllPacientes()
        {
            return _context.PacienteModel.ToList();
        }

        public void CreatePaciente(PacienteModel nuevoPaciente)
        {
            _context.PacienteModel.Add(nuevoPaciente);
            _context.SaveChanges();
        }

        public void UpdatePaciente(PacienteModel pacienteActualizado)
        {
            _context.PacienteModel.Update(pacienteActualizado);
            _context.SaveChanges();
        }

        public PacienteModel GetPacienteById(int id)
        {
            return _context.PacienteModel.FirstOrDefault(p => p.ClienteId == id);
        }
    }
}
