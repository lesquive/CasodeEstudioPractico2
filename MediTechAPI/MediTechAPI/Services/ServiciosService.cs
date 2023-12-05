using System;
using System.Collections.Generic;
using System.Linq;
using MediTechAPI.Models;

namespace MediTechAPI.Services
{
    public class ServiciosService
    {
        private readonly MediTechDbContext _context;

        public ServiciosService(MediTechDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<ServiciosModel> GetAllServicios()
        {
            return _context.ServiciosModel.ToList();
        }

        public void CreateServicio(ServiciosModel nuevoServicio)
        {
            _context.ServiciosModel.Add(nuevoServicio);
            _context.SaveChanges();
        }

        public void UpdateServicio(ServiciosModel servicioActualizado)
        {
            _context.ServiciosModel.Update(servicioActualizado);
            _context.SaveChanges();
        }

        public ServiciosModel GetServicioById(int id)
        {
            return _context.ServiciosModel.FirstOrDefault(s => s.Id == id);
        }
    }
}
