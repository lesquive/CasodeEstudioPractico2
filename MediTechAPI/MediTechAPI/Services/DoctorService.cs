using System;
using System.Collections.Generic;
using System.Linq;
using MediTechAPI.Models;

namespace MediTechAPI.Services
{
    public class DoctorService
    {
        private readonly MediTechDbContext _context;

        public DoctorService(MediTechDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<DoctorModel> GetAllDoctors()
        {
            return _context.DoctorModel.ToList();
        }

        public void CreateDoctor(DoctorModel nuevoDoctor)
        {
            _context.DoctorModel.Add(nuevoDoctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(DoctorModel doctorActualizado)
        {
            _context.DoctorModel.Update(doctorActualizado);
            _context.SaveChanges();
        }

        public DoctorModel GetDoctorById(int id)
        {
            return _context.DoctorModel.FirstOrDefault(d => d.DoctorId == id);
        }
    }
}
