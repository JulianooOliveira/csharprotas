using Microsoft.EntityFrameworkCore;
using models;

namespace models
{
    public class PacienteContext : DbContext
    {
        public PacienteContext(DbContextOptions<PacienteContext> options) : base(options) { }

        public DbSet<Paciente> pacientes { get; set; }
    }
}