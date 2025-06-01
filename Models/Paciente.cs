using System;

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
}

}
