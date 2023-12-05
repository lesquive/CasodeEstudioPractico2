using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace MediTechAPI.Models
{
	public class MediTechDbContext : DbContext
    {
        public MediTechDbContext(DbContextOptions<MediTechDbContext> options) : base(options)
        {
        }

        public DbSet<ServiciosModel> ServiciosModel { get; set; }
        public DbSet<PacienteModel> PacienteModel { get; set; }
        public DbSet<RegistrarCitaModel> RegistrarCitaModel { get; set; }
        public DbSet<DoctorModel> DoctorModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("MediTechDbContext", new MySqlServerVersion(new Version(8, 0, 25)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ServiciosModel>().HasData(
                new ServiciosModel { Id = 1, Nombre = "Consulta General" },
                new ServiciosModel { Id = 2, Nombre = "Análisis de Sangre" },
                new ServiciosModel { Id = 3, Nombre = "Radiografía" },
                new ServiciosModel { Id = 4, Nombre = "Cirugía Menor" },
                new ServiciosModel { Id = 5, Nombre = "Servicio Dental" }
            );

            modelBuilder.Entity<PacienteModel>().HasData(
                new PacienteModel
                {
                    ClienteId = 1,
                    Nombre = "Nombre1",
                    Apellido = "Apellido1",
                    Email = "nombre1@example.com",
                    Telefono = "123456789",
                    Direccion = "Dirección 1"
                },
                new PacienteModel
                {
                    ClienteId = 2,
                    Nombre = "Nombre2",
                    Apellido = "Apellido2",
                    Email = "nombre2@example.com",
                    Telefono = "987654321",
                    Direccion = "Dirección 2"
                },
                new PacienteModel
                {
                    ClienteId = 3,
                    Nombre = "Nombre3",
                    Apellido = "Apellido3",
                    Email = "nombre3@example.com",
                    Telefono = "111222333",
                    Direccion = "Dirección 3"
                },
                new PacienteModel
                {
                    ClienteId = 4,
                    Nombre = "Nombre4",
                    Apellido = "Apellido4",
                    Email = "nombre4@example.com",
                    Telefono = "444555666",
                    Direccion = "Dirección 4"
                },
                new PacienteModel
                {
                    ClienteId = 5,
                    Nombre = "Nombre5",
                    Apellido = "Apellido5",
                    Email = "nombre5@example.com",
                    Telefono = "777888999",
                    Direccion = "Dirección 5"
                }
            );

            modelBuilder.Entity<DoctorModel>().HasData(
                new DoctorModel
                {
                    DoctorId = 1,
                    Nombre = "Nombre1",
                    Apellido = "Apellido1",
                    Email = "nombre1@example.com",
                    Telefono = "123456789",
                    Direccion = "Dirección 1",
                    Especialidad = "Medicina General",
                    AniosExperiencia = 5
                },
                new DoctorModel
                {
                    DoctorId = 2,
                    Nombre = "Nombre2",
                    Apellido = "Apellido2",
                    Email = "nombre2@example.com",
                    Telefono = "987654321",
                    Direccion = "Dirección 2",
                    Especialidad = "Cardiología",
                    AniosExperiencia = 8
                },
                new DoctorModel
                {
                    DoctorId = 3,
                    Nombre = "Nombre3",
                    Apellido = "Apellido3",
                    Email = "nombre3@example.com",
                    Telefono = "111222333",
                    Direccion = "Dirección 3",
                    Especialidad = "Dermatología",
                    AniosExperiencia = 10
                },
                new DoctorModel
                {
                    DoctorId = 4,
                    Nombre = "Nombre4",
                    Apellido = "Apellido4",
                    Email = "nombre4@example.com",
                    Telefono = "444555666",
                    Direccion = "Dirección 4",
                    Especialidad = "Gastroenterología",
                    AniosExperiencia = 6
                },
                new DoctorModel
                {
                    DoctorId = 5,
                    Nombre = "Nombre5",
                    Apellido = "Apellido5",
                    Email = "nombre5@example.com",
                    Telefono = "777888999",
                    Direccion = "Dirección 5",
                    Especialidad = "Neurología",
                    AniosExperiencia = 12
                }
            );

            modelBuilder.Entity<RegistrarCitaModel>().HasData(
                new RegistrarCitaModel
                {
                    Id = 1,
                    PacienteId = 1,
                    ServicioId = 1,
                    DoctorId = 1,
                    Nota = "Nota de cita 1 con al menos 20 caracteres."
                },
                new RegistrarCitaModel
                {
                    Id = 2,
                    PacienteId = 2,
                    ServicioId = 2,
                    DoctorId = 2,
                    Nota = "Nota de cita 2 con más de 20 caracteres."
                },
                new RegistrarCitaModel
                {
                    Id = 3,
                    PacienteId = 3,
                    ServicioId = 3,
                    DoctorId = 3,
                    Nota = "Nota de cita 3 con 20+ caracteres."
                },
                new RegistrarCitaModel
                {
                    Id = 4,
                    PacienteId = 4,
                    ServicioId = 4,
                    DoctorId = 4,
                    Nota = "Nota de cita 4 con suficientes caracteres."
                },
                new RegistrarCitaModel
                {
                    Id = 5,
                    PacienteId = 5,
                    ServicioId = 5,
                    DoctorId = 5,
                    Nota = "Nota de cita 5 con texto suficiente."
                }
            );

        }

    }
}

