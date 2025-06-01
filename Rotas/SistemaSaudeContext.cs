using ApiEspecialidade.Models;
using ApiMedico.Models;
using ApiPaciente.Models;
using Microsoft.EntityFrameworkCore;


namespace Context.Modelo
{
    public class SistemaSaudeContext : DbContext
    {
        public SistemaSaudeContext(DbContextOptions<SistemaSaudeContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
    }
}