using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediTechAPI.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DoctorModel",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AniosExperiencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorModel", x => x.DoctorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PacienteModel",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteModel", x => x.ClienteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegistrarCitaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrarCitaModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServiciosModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "DoctorModel",
                columns: new[] { "DoctorId", "AniosExperiencia", "Apellido", "Direccion", "Email", "Especialidad", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, 5, "Apellido1", "Dirección 1", "nombre1@example.com", "Medicina General", "Nombre1", "123456789" },
                    { 2, 8, "Apellido2", "Dirección 2", "nombre2@example.com", "Cardiología", "Nombre2", "987654321" },
                    { 3, 10, "Apellido3", "Dirección 3", "nombre3@example.com", "Dermatología", "Nombre3", "111222333" },
                    { 4, 6, "Apellido4", "Dirección 4", "nombre4@example.com", "Gastroenterología", "Nombre4", "444555666" },
                    { 5, 12, "Apellido5", "Dirección 5", "nombre5@example.com", "Neurología", "Nombre5", "777888999" }
                });

            migrationBuilder.InsertData(
                table: "PacienteModel",
                columns: new[] { "ClienteId", "Apellido", "Direccion", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Apellido1", "Dirección 1", "nombre1@example.com", "Nombre1", "123456789" },
                    { 2, "Apellido2", "Dirección 2", "nombre2@example.com", "Nombre2", "987654321" },
                    { 3, "Apellido3", "Dirección 3", "nombre3@example.com", "Nombre3", "111222333" },
                    { 4, "Apellido4", "Dirección 4", "nombre4@example.com", "Nombre4", "444555666" },
                    { 5, "Apellido5", "Dirección 5", "nombre5@example.com", "Nombre5", "777888999" }
                });

            migrationBuilder.InsertData(
                table: "RegistrarCitaModel",
                columns: new[] { "Id", "DoctorId", "Nota", "PacienteId", "ServicioId" },
                values: new object[,]
                {
                    { 1, 1, "Nota de cita 1 con al menos 20 caracteres.", 1, 1 },
                    { 2, 2, "Nota de cita 2 con más de 20 caracteres.", 2, 2 },
                    { 3, 3, "Nota de cita 3 con 20+ caracteres.", 3, 3 },
                    { 4, 4, "Nota de cita 4 con suficientes caracteres.", 4, 4 },
                    { 5, 5, "Nota de cita 5 con texto suficiente.", 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "ServiciosModel",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Consulta General" },
                    { 2, "Análisis de Sangre" },
                    { 3, "Radiografía" },
                    { 4, "Cirugía Menor" },
                    { 5, "Servicio Dental" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorModel");

            migrationBuilder.DropTable(
                name: "PacienteModel");

            migrationBuilder.DropTable(
                name: "RegistrarCitaModel");

            migrationBuilder.DropTable(
                name: "ServiciosModel");
        }
    }
}
