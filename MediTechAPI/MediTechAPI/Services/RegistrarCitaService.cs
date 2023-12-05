using System;
using System.Collections.Generic;
using System.Linq;
using MediTechAPI.Models;

namespace MediTechAPI.Services
{
    public class RegistrarCitaService
    {
        private readonly MediTechDbContext _context;

        public RegistrarCitaService(MediTechDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<RegistrarCitaModel> GetAllCitas()
        {
            return _context.RegistrarCitaModel.ToList();
        }

        public void CreateCita(RegistrarCitaModel nuevaCita)
        {
            _context.RegistrarCitaModel.Add(nuevaCita);
            _context.SaveChanges();
        }

        public void UpdateCita(RegistrarCitaModel citaActualizada)
        {
            _context.RegistrarCitaModel.Update(citaActualizada);
            _context.SaveChanges();
        }

        public RegistrarCitaModel GetCitaById(int id)
        {
            return _context.RegistrarCitaModel.FirstOrDefault(c => c.Id == id);
        }
    }
}
