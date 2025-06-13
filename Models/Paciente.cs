using System;
using ApiMedico.Models;
using ApiEspecialidade.Models;

namespace ApiPaciente.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public required string NomeCompleto { get; set; }
        public required string Nascimento { get; set; }
        public required string DocumentoCPF { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public required string Endereco { get; set; }

        public int IdMedico { get; set; }
        public int IdEspecialidade { get; set; }
        public decimal ValorConsulta { get; set; }

        public Medico? Medico { get; set; }
        public Especialidade? Especialidade { get; set; }
    }
}